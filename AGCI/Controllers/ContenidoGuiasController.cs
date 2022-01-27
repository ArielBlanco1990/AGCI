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
    public class ContenidoGuiasController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: ContenidoGuias
        public ActionResult Index()
        {
            var contenidoGuias = db.ContenidoGuias.Include(c => c.Guia);
            return View(contenidoGuias.ToList());
        }



        // GET: ContenidoGuias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContenidoGuia contenidoGuia = db.ContenidoGuias.Find(id);
            if (contenidoGuia == null)
            {
                return HttpNotFound();
            }
            return View(contenidoGuia);
        }

        // GET: ContenidoGuias/Create
        public ActionResult Create()
        {
            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id");
            return View();
        }

        // POST: ContenidoGuias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CGR,Otros,NoP,NoPreguntas,Numero,Nombre,Si,No,Np,Responsable,JefeInmediato,Direccion,ComponenteDescripcion,Norma,GuiaId")] ContenidoGuia contenidoGuia)
        {
            if (ModelState.IsValid)
            {
                db.ContenidoGuias.Add(contenidoGuia);
                db.SaveChanges();
                TempData["exito"] = "El contenido se ha creado correctamente.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error al intentar insertar el contenido.";
            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id", contenidoGuia.GuiaId);
            return View(contenidoGuia);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContenidoGuia contenidoGuia = db.ContenidoGuias.Find(id);
            if (contenidoGuia == null)
            {
                return HttpNotFound();
            }
            var Resp = new List<dynamic>() {
                new { Id = 1, Nombre = "Si"},
                new { Id = 2, Nombre = "No" },
                new { Id = 3, Nombre = "No Procede" }


            };
            ViewBag.Responsable = false;
            ViewBag.JefeInmediato = false;
           
            ViewBag.Respuesta = new SelectList(Resp, "Id", "Nombre", contenidoGuia.Respuesta);
            ViewBag.ResponsableId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", contenidoGuia.Responsable);
            ViewBag.JefeInmediatoId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", contenidoGuia.JefeInmediato);
            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id", contenidoGuia.GuiaId);
            ViewBag.Guia = contenidoGuia.GuiaId;
            return View("Editar", contenidoGuia);
        }
        // POST: ContenidoGuias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ContenidoGuia contenidoGuia, string ResponsableId, string JefeInmediatoId, int Respuesta)
        {

            if (Respuesta == 1)
            {
                if (db.PlanDeMedida.Any(s => s.DeficienciasSeñaladas.Equals(contenidoGuia.Nombre) && s.GuiaId == contenidoGuia.GuiaId))
                {
                    var plan = db.PlanDeMedida.SingleOrDefault(s => s.DeficienciasSeñaladas.Equals(contenidoGuia.Nombre) && s.GuiaId == contenidoGuia.GuiaId);
                    db.PlanDeMedida.Remove(plan);
                    db.SaveChanges();
                };
                contenidoGuia.Si = 1;
                contenidoGuia.No = null;
                contenidoGuia.Np = null;
                contenidoGuia.Respuesta = 1;
            }
            if (Respuesta == 2)
            {
                contenidoGuia.Si = null;
                contenidoGuia.No = 1;
                contenidoGuia.Np = null;
                contenidoGuia.Respuesta = 2;
                var guia = db.Guias.SingleOrDefault(s => s.Id == contenidoGuia.GuiaId);
                if (!db.PlanDeMedida.Any(s => s.Numero == contenidoGuia.NoPreguntas && s.DeficienciasSeñaladas == contenidoGuia.Nombre && s.GuiaId == guia.Id))
                {
                    var plan = new PlanDeMedida { Numerador = guia.PlanDeMedidas.Count + 1, Numero = contenidoGuia.NoPreguntas, DeficienciasSeñaladas = contenidoGuia.Nombre, GuiaId = guia.Id };
                    db.PlanDeMedida.Add(plan);
                    db.SaveChanges();
                    TempData["notice"] = "Se generó un plan de medidas.";
                }


            }
            if (Respuesta == 3)
            {
                if (db.PlanDeMedida.Any(s => s.Numero == contenidoGuia.Numero && s.GuiaId == contenidoGuia.GuiaId))
                {
                    var plan = db.PlanDeMedida.SingleOrDefault(s => s.Numero == contenidoGuia.Numero && s.GuiaId == contenidoGuia.GuiaId);
                    db.PlanDeMedida.Remove(plan);
                    db.SaveChanges();
                };
                contenidoGuia.Si = null;
                contenidoGuia.No = null;
                contenidoGuia.Np = 1;
                contenidoGuia.Respuesta = 3;
            }
            contenidoGuia.JefeInmediato = JefeInmediatoId;
            contenidoGuia.Responsable = ResponsableId;
            if (ModelState.IsValid)
            {
                db.Entry(contenidoGuia).State = EntityState.Modified;
                db.SaveChanges();
                TempData["exito"] = "El contenido se ha editado correctamente.";
                return RedirectToAction("Details", "Guias", new { id = contenidoGuia.GuiaId });
            }
            TempData["error"] = "Error al intentar editar el contenido.";
            var Resp = new List<dynamic>() {
                new { Id = 1, Nombre = "Si"},
                new { Id = 2, Nombre = "No" },
                new { Id = 3, Nombre = "No Procede" }

            };
            ViewBag.Respuesta = new SelectList(Resp, "Id", "Nombre", contenidoGuia.Respuesta);
            ViewBag.ResponsableId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", contenidoGuia.Responsable);
            ViewBag.JefeInmediatoId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", contenidoGuia.JefeInmediato);
            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id", contenidoGuia.GuiaId);
            ViewBag.Guia = contenidoGuia.GuiaId;
            return View(contenidoGuia);
        }

        // GET: ContenidoGuias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContenidoGuia contenidoGuia = db.ContenidoGuias.Find(id);
            if (contenidoGuia == null)
            {
                return HttpNotFound();
            }
            var Resp = new List<dynamic>() {
                new { Id = 1, Nombre = "Si"},
                new { Id = 2, Nombre = "No" },
                new { Id = 3, Nombre = "No Procede" }

            };
            ViewBag.Responsable = false;
            ViewBag.JefeInmediato = false;
            if (contenidoGuia.Responsable != null)
            {
                ViewBag.Responsable = true;
            }
            if (contenidoGuia.JefeInmediato != null)
            {
                ViewBag.JefeInmediato = true;
            }
            ViewBag.Respuesta = new SelectList(Resp, "Id", "Nombre", contenidoGuia.Respuesta);
            var resp = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", contenidoGuia.Responsable);

            ViewBag.ResponsableId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", contenidoGuia.Responsable);
            ViewBag.JefeInmediatoId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", contenidoGuia.JefeInmediato);
            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id", contenidoGuia.GuiaId);
            ViewBag.Guia = contenidoGuia.GuiaId;
            return View(contenidoGuia);
        }


        // POST: ContenidoGuias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContenidoGuia contenidoGuia, string ResponsableId, string JefeInmediatoId, int Respuesta)
        {

            if (Respuesta == 1)
            {
                if (db.PlanDeMedida.Any(s => s.DeficienciasSeñaladas.Equals(contenidoGuia.Nombre) && s.GuiaId == contenidoGuia.GuiaId))
                {
                    var plan = db.PlanDeMedida.SingleOrDefault(s => s.DeficienciasSeñaladas.Equals(contenidoGuia.Nombre) && s.GuiaId == contenidoGuia.GuiaId);
                    db.PlanDeMedida.Remove(plan);
                    db.SaveChanges();
                };
                contenidoGuia.Si = 1;
                contenidoGuia.No = null;
                contenidoGuia.Np = null;
                contenidoGuia.Respuesta = 1;
            }
            if (Respuesta == 2)
            {
                contenidoGuia.Si = null;
                contenidoGuia.No = 1;
                contenidoGuia.Np = null;
                contenidoGuia.Respuesta = 2;
                var guia = db.Guias.SingleOrDefault(s => s.Id == contenidoGuia.GuiaId);
                var plan = new PlanDeMedida { Numerador = guia.PlanDeMedidas.Count + 1, Numero = contenidoGuia.NoPreguntas, DeficienciasSeñaladas = contenidoGuia.Nombre, GuiaId = guia.Id };
                db.PlanDeMedida.Add(plan);
                db.SaveChanges();
                TempData["notice"] = "Se generó un plan de medidas.";

            }
            if (Respuesta == 3)
            {
                if (db.PlanDeMedida.Any(s => s.Numero == contenidoGuia.Numero && s.GuiaId == contenidoGuia.GuiaId))
                {
                    var plan = db.PlanDeMedida.SingleOrDefault(s => s.Numero == contenidoGuia.Numero && s.GuiaId == contenidoGuia.GuiaId);
                    db.PlanDeMedida.Remove(plan);
                    db.SaveChanges();
                };
                contenidoGuia.Si = null;
                contenidoGuia.No = null;
                contenidoGuia.Np = 1;
                contenidoGuia.Respuesta = 3;
            }
            contenidoGuia.JefeInmediato = JefeInmediatoId;
            contenidoGuia.Responsable = ResponsableId;
            if (ModelState.IsValid)
            {
                db.Entry(contenidoGuia).State = EntityState.Modified;
                db.SaveChanges();
                TempData["exito"] = "El contenido se ha creado correctamente.";
                return RedirectToAction("Details", "Guias", new { id = contenidoGuia.GuiaId });
            }
            TempData["error"] = "Error al intentar insertar el contenido.";
            var Resp = new List<dynamic>() {
                new { Id = 1, Nombre = "Si"},
                new { Id = 2, Nombre = "No" },
                new { Id = 3, Nombre = "No Procede" }


            };
            ViewBag.Respuesta = new SelectList(Resp, "Id", "Nombre", contenidoGuia.Respuesta);
            ViewBag.ResponsableId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", contenidoGuia.Responsable);
            ViewBag.JefeInmediatoId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", contenidoGuia.JefeInmediato);
            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id", contenidoGuia.GuiaId);
            ViewBag.Guia = contenidoGuia.GuiaId;
            return View(contenidoGuia);
        }

        public ActionResult Check(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guia guia = db.Guias.Include(s => s.Contenido).SingleOrDefault(s => s.Id == id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            foreach (var item in guia.Contenido)
            {
                if (item.NoPreguntas > 0)
                {


                    if (item.Otros == null && item.Numero == null && item.NoP == null)
                    {

                    }
                    else
                    {
                        item.Si = 1;
                        db.Entry(item).State = EntityState.Modified;
                    }

                }
                else
                {

                }

            }
            db.SaveChanges();
            TempData["exito"] = "Los contenidos se han ediato correctamente.";
            return RedirectToAction("Details", "Guias", new { id });
        }

        public ActionResult Clean(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContenidoGuia contenido = db.ContenidoGuias.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            contenido.Responsable = null;
            contenido.JefeInmediato = null;
            contenido.Si = null;
            contenido.No = null;
            contenido.Np = null;
            db.Entry(contenido).State = EntityState.Modified;
            db.SaveChanges();
            TempData["exito"] = "Los contenidos se han ediato correctamente.";
            return RedirectToAction("Details", "Guias", new { id = contenido.GuiaId });
        }
        // GET: ContenidoGuias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContenidoGuia contenidoGuia = db.ContenidoGuias.Find(id);
            if (contenidoGuia == null)
            {
                return HttpNotFound();
            }
            return View(contenidoGuia);
        }

        // POST: ContenidoGuias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContenidoGuia contenidoGuia = db.ContenidoGuias.Find(id);
            db.ContenidoGuias.Remove(contenidoGuia);
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
