using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGCI.AuxClasses;
using AGCI.Models;

namespace AGCI.Controllers
{
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
    public class GuiasController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: Guias
        public ActionResult Index()
        {
            if (User.IsInRole(RolesAGCI.Administrador) || User.IsInRole(RolesAGCI.Auditor) || User.IsInRole(RolesAGCI.Consultor))
            {
                var guia = db.Guias.Include(g => g.Area);
                return View(guia.ToList());
            }
            var trabajador = db.Trabajadores.Include(s => s.Usuario).Include(s => s.TrabajadorArea).SingleOrDefault(s => s.Usuario.UserName == User.Identity.Name);
            var guide = new List<Guia>();
            foreach (var item in trabajador.TrabajadorArea)
            {
                var select = db.Guias.Include(g => g.Area).Where(s => s.AreaId == item.AreaId);
                foreach (var item2 in select)
                {
                    guide.Add(item2);
                }

            }

            //var guias = db.Guias.Include(g => g.Area).Where(s => s.AreaId == trabajador.TrabajadorArea);
            return View(guide.OrderByDescending(s => s.Numerador).ToList());
        }

        // GET: Guias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var guia = db.Guias
               .Include(g => g.Area).Include(g => g.Area.UnidadOrganizativa).Include(g => g.Contenido)
               .FirstOrDefault(m => m.Id == id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuiaId = id;
            ViewBag.Unidad = guia.Area.UnidadOrganizativa.Nombre;
            return View(guia.Contenido);
        }

        public ActionResult Planes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var guia = db.Guias
               .Include(g => g.Area).Include(g => g.Area.UnidadOrganizativa).Include(g => g.Contenido).Include(g => g.PlanDeMedidas)
               .FirstOrDefault(m => m.Id == id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Unidad = guia.Area.UnidadOrganizativa.Nombre;
            ViewBag.Guia = guia.Id;
            return View(guia.PlanDeMedidas);
        }

        // GET: Guias/Create
        public ActionResult Create()
        {
            var Meses = new List<dynamic>() {
                new { Id = 1, Nombre = Mes.Enero },
                new { Id = 2, Nombre = Mes.Feberero },
                new { Id = 3, Nombre = Mes.Marzo },
                new { Id = 4, Nombre = Mes.Abril },
                new { Id = 5, Nombre = Mes.Mayo },
                new { Id = 6, Nombre = Mes.Junio },
                new { Id = 7, Nombre = Mes.Julio },
                new { Id = 8, Nombre= Mes.Agosto },
                new { Id = 9, Nombre= Mes.Septiembre },
                new { Id = 10, Nombre = Mes.Octubre },
                new { Id = 11, Nombre= Mes.Noviembre },
                new { Id = 12, Nombre = Mes.Diciembre }
            };
            ViewBag.Mesok = new SelectList(Meses, "Id", "Nombre");
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre");
            return View();
        }

        // POST: Guias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AreaId,Año,Mes")] Guia guia, int Mesok)
        {
            if (db.Guias.Any(s => s.Mes == Mesok && s.Año == guia.Año && s.AreaId == guia.AreaId))
            {
                TempData["error"] = "Ya existe esa guia!.";
                return RedirectToAction("Index");
            }
            guia.Mes = Mesok;
            var area = db.Areas.SingleOrDefault(s => s.Id == guia.AreaId);

            if (ModelState.IsValid)
            {
                db.Guias.Add(guia);
                db.SaveChanges();
                int leyAnt = 1;
                foreach (var item in db.ModelosGuias.Where(s => s.Direccion.Trim().ToUpper().Equals(area.Nombre.Trim().ToUpper())).ToList())
                {
                    if (item.CGR != null)
                    {
                        leyAnt = item.Id;
                    }
                    if (item.Nombre.Equals("Atención a la población ( Quejas y Denuncias.)"))
                    {
                        var X = 1;
                    }
                    bool componente = false;
                    bool norma = false;
                    bool grupo = false;
                    bool pregunta = false;
                    if (!item.Nombre.Contains("GUIA"))
                    {


                        ///COMPONENTE
                        if (item.Norma == null && !item.ComponenteDescripcion.Equals(""))
                        {
                            componente = true;
                        }
                        var component = db.Componentes.Include(s => s.Normas).SingleOrDefault(s => s.Descripcion.Equals(item.ComponenteDescripcion));
                        ///NORMA
                        if (item.Norma != null && !item.ComponenteDescripcion.Equals("") && item.CGR == null && item.Otros == null && (item.NoPreguntas == null || item.NoPreguntas == 0) && item.Numero == null && item.Si > 1)
                        {
                            norma = true;
                        }

                        if (norma == true)
                        {
                            if (item.Norma != null && !db.Normas.Any(s => s.Nombre.Equals(item.Norma)))
                            {
                                db.Normas.Add(new Norma { Nombre = item.Norma, ComponenteId = component.Id });
                                db.SaveChanges();
                            }

                            var normas = db.Normas.SingleOrDefault(s => s.Nombre.Equals(item.Norma));

                            guia.Contenido.Add(new ContenidoGuia
                            {
                                CGR = item.CGR,
                                ComponenteDescripcion = item.ComponenteDescripcion,
                                Direccion = area.Nombre,
                                JefeInmediato = "",
                                No = item.No,
                                Nombre = item.Nombre,
                                NoP = item.NoP,
                                NoPreguntas = item.NoPreguntas,
                                NormaId = normas.Id,
                                NormaName = normas.Nombre,
                                Np = item.Np,
                                Numero = item.Numero,
                                Otros = item.Otros,
                                Responsable = item.Responsable,
                                ComponenteId = component.Id,
                                Tipo = "Norma"

                            });
                        }
                        if (componente)
                        {
                            guia.Contenido.Add(new ContenidoGuia
                            {
                                CGR = item.CGR,
                                ComponenteDescripcion = item.ComponenteDescripcion,
                                Direccion = area.Nombre,
                                JefeInmediato = "",
                                No = item.No,
                                Nombre = item.Nombre,
                                NoP = item.NoP,
                                NoPreguntas = item.NoPreguntas,
                                NormaId = null,
                                Np = item.Np,
                                Numero = item.Numero,
                                Otros = item.Otros,
                                Responsable = item.Responsable,
                                ComponenteId = component.Id,
                                Tipo = "Componente"
                            });
                        }
                        ///GRUPO
                        if (item.Norma != null &&
                            !item.ComponenteDescripcion.Equals("") &&
                            (item.NoPreguntas == null || item.NoPreguntas == 0) &&
                            item.NoP == 0 &&
                            item.Si == null

                            )
                        {
                            grupo = true;
                        }
                        if (grupo)
                        {
                            var normas = db.Normas.SingleOrDefault(s => s.Nombre.Equals(item.Norma));
                            if (!db.GrupoPreguntas.Any(s => s.Nombre.Equals(item.Nombre)))
                            {
                                db.GrupoPreguntas.Add(new GrupoPregunta
                                {
                                    Nombre = item.Nombre,
                                    NormaId = normas.Id,
                                    Descripcion = component.Descripcion
                                });
                                db.SaveChanges();
                            }

                            guia.Contenido.Add(new ContenidoGuia
                            {
                                CGR = item.CGR,
                                ComponenteDescripcion = item.ComponenteDescripcion,
                                Direccion = area.Nombre,
                                JefeInmediato = "",
                                No = item.No,
                                Nombre = item.Nombre,
                                NoP = item.NoP,
                                NoPreguntas = item.NoPreguntas,
                                NormaName = normas.Nombre,
                                NormaId = normas.Id,
                                Np = item.Np,
                                Numero = item.Numero,
                                Otros = item.Otros,
                                Responsable = item.Responsable,
                                ComponenteId = component.Id,
                                Tipo = "Grupo"
                            });
                        }
                        ///PREGUNTA
                        if (item.Norma != null &&
                            !item.ComponenteDescripcion.Equals("") &&
                            item.NoPreguntas > 0 &&
                            item.NoP == 0)
                        {
                            pregunta = true;
                        }
                        if (pregunta)
                        {
                            if (item.CGR != null)
                            {
                                if (!db.Leyes.Any(s => s.Nombre.ToUpper().Trim().Equals(item.CGR.ToUpper().Trim())))
                                {
                                    db.Leyes.Add(new Ley { Nombre = item.CGR.ToUpper().Trim() });
                                    db.SaveChanges();
                                }
                            }
                            if ((item.CGR!=null))
                            {
                                if (item.CGR.Equals("1-67 CGR"))
                                {
                                    var x = 1;
                                }
                            }
                          
                            if (item.CGR == null)
                            {
                                var x = 1;
                            }

                            var normas = db.Normas.SingleOrDefault(s => s.Nombre.Equals(item.Norma));
                            var leyOld = db.ModelosGuias.SingleOrDefault(s => s.Id == leyAnt);
                            var ley = item.CGR == null ? db.Leyes.SingleOrDefault(s => s.Nombre.ToUpper().Trim().Equals(leyOld.CGR.ToUpper().Trim())) : db.Leyes.SingleOrDefault(s => s.Nombre.ToUpper().Trim().Equals(item.CGR.ToUpper().Trim()));

                            if (normas.GrupoPreguntas.Count() <= 0)
                            {
                                db.Preguntas.Add(new Pregunta
                                {
                                    ComponenteDescripcion = item.ComponenteDescripcion,
                                    Direccion = area.Nombre,
                                    Nombre = item.Nombre,
                                    NormaName = normas.Nombre,
                                    NormaId = normas.Id,
                                    LeyId = ley.Id

                                });
                                guia.Contenido.Add(new ContenidoGuia
                                {
                                    CGR = item.CGR,
                                    ComponenteDescripcion = item.ComponenteDescripcion,
                                    Direccion = area.Nombre,
                                    JefeInmediato = "",
                                    No = item.No,
                                    Nombre = item.Nombre,
                                    NoP = item.NoP,
                                    NoPreguntas = item.NoPreguntas,
                                    NormaName = normas.Nombre,
                                    NormaId = normas.Id,
                                    Np = item.Np,
                                    Numero = item.Numero,
                                    Otros = item.Otros,
                                    Responsable = item.Responsable,
                                    ComponenteId = component.Id,
                                    LeyId = ley.Id,
                                    FechaDeVencimiento = ley.FechaVencimiento,
                                    Tipo = "Pregunta"
                                });
                            }
                            else
                            {

                                var grupoP = db.GrupoPreguntas.ToList().Last().Id;
                                db.Preguntas.Add(new Pregunta
                                {
                                    ComponenteDescripcion = item.ComponenteDescripcion,
                                    Direccion = area.Nombre,
                                    Nombre = item.Nombre,
                                    NormaName = normas.Nombre,
                                    GrupoPreguntaId = grupoP,
                                    LeyId = ley.Id
                                });
                                guia.Contenido.Add(new ContenidoGuia
                                {
                                    CGR = item.CGR,
                                    ComponenteDescripcion = item.ComponenteDescripcion,
                                    Direccion = area.Nombre,
                                    JefeInmediato = "",
                                    No = item.No,
                                    Nombre = item.Nombre,
                                    NoP = item.NoP,
                                    NoPreguntas = item.NoPreguntas,
                                    NormaName = normas.Nombre,
                                    NormaId = normas.Id,
                                    Np = item.Np,
                                    Numero = item.Numero,
                                    Otros = item.Otros,
                                    Responsable = item.Responsable,
                                    ComponenteId = component.Id,
                                    LeyId = ley.Id,
                                    FechaDeVencimiento = ley.FechaVencimiento,
                                    Tipo = "Pregunta"
                                });
                            }

                        }
                        db.Entry(guia).State = EntityState.Modified;
                        db.SaveChanges();
                        TempData["exito"] = "La guia se ha creado correctamente.";
                    }

                }
                return RedirectToAction("Index");
            }

            var Meses = new List<dynamic>() {
                new { Id = 1, Nombre = Mes.Enero },
                new { Id = 2, Nombre = Mes.Feberero },
                new { Id = 3, Nombre = Mes.Marzo },
                new { Id = 4, Nombre = Mes.Abril },
                new { Id = 5, Nombre = Mes.Mayo },
                new { Id = 6, Nombre = Mes.Junio },
                new { Id = 7, Nombre = Mes.Julio },
                new { Id = 8, Nombre= Mes.Agosto },
                new { Id = 9, Nombre= Mes.Septiembre },
                new { Id = 10, Nombre = Mes.Octubre },
                new { Id = 11, Nombre= Mes.Noviembre },
                new { Id = 12, Nombre = Mes.Diciembre }
            };
            ViewBag.Mesok = new SelectList(Meses, "Id", "Nombre", guia.Mes);
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre", guia.AreaId);
            return View(guia);
        }

        // POST: Guias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //// GET: Guias/Create
        //public ActionResult CreateFull()
        //{
        //    var Meses = new List<dynamic>() {
        //        new { Id = 1, Nombre = Mes.Enero },
        //        new { Id = 2, Nombre = Mes.Feberero },
        //        new { Id = 3, Nombre = Mes.Marzo },
        //        new { Id = 4, Nombre = Mes.Abril },
        //        new { Id = 5, Nombre = Mes.Mayo },
        //        new { Id = 6, Nombre = Mes.Junio },
        //        new { Id = 7, Nombre = Mes.Julio },
        //        new { Id = 8, Nombre= Mes.Agosto },
        //        new { Id = 9, Nombre= Mes.Septiembre },
        //        new { Id = 10, Nombre = Mes.Octubre },
        //        new { Id = 11, Nombre= Mes.Noviembre },
        //        new { Id = 12, Nombre = Mes.Diciembre }
        //    };
        //    ViewBag.MesOk = new SelectList(Meses, "Id", "Nombre");
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateFull(int Año, int MesOk)
        //{
        //    var areas = db.Areas.ToList();

        //    foreach (var areax in areas)
        //    {
        //        if (!db.Guias.Any(s => s.Año == Año && s.Mes == MesOk && s.AreaId == areax.Id))
        //        {
        //            var guia = new Guia
        //            {
        //                Mes = MesOk,
        //                AreaId = areax.Id,
        //                Año = Año,
        //            };
        //            db.Guias.Add(guia);
        //            db.SaveChanges();
        //            var area = db.Areas.SingleOrDefault(s => s.Id == guia.AreaId);
        //            foreach (var item in db.ModelosGuias.ToList())
        //            {
        //                guia.Contenido.Add(new ContenidoGuia
        //                {
        //                    CGR = item.CGR,
        //                    ComponenteDescripcion = item.ComponenteDescripcion,
        //                    Direccion = area.Nombre,
        //                    JefeInmediato = "",
        //                    No = item.No,
        //                    Nombre = item.Nombre,
        //                    NoP = item.NoP,
        //                    NoPreguntas = item.NoPreguntas,
        //                    Norma = item.Norma,
        //                    Np = item.Np,
        //                    Numero = item.Numero,
        //                    Otros = item.Otros,
        //                    Responsable = item.Responsable,
        //                    Si = item.Si
        //                });
        //                db.Entry(guia).State = EntityState.Modified;
        //                db.SaveChanges();
        //                TempData["exito"] = "Las guias se han creado correctamentes.";
        //                return RedirectToAction("Index");
        //            }

        //        }
        //    }
        //    return View("Index");
        //}
        // GET: Guias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guia guia = db.Guias.Find(id);
            if (guia == null)
            {
                return HttpNotFound();
            }

            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre", guia.AreaId);
            return View(guia);
        }

        // POST: Guias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AreaId,Año,Mes")] Guia guia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guia).State = EntityState.Modified;
                db.SaveChanges();
                TempData["exito"] = "La guia se ha editado correctamente.";
                return RedirectToAction("Index");

            }
            TempData["error"] = "La guia no se pudo editar correctamente.";
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre", guia.AreaId);
            return View(guia);
        }

        // GET: Guias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guia guia = db.Guias.Find(id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            return View(guia);
        }

        // POST: Guias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guia guia = db.Guias.Find(id);
            db.Guias.Remove(guia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
