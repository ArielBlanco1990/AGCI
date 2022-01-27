using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using AGCI.ViewModels;
using AGCI.Models;


namespace AGCI.Controllers
{
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
    public class AreaController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: /Area/
        public ActionResult Index()
        {
            var areas = new List<AreaViewModel>();
            foreach (var area in db.Areas.Include(t => t.UnidadOrganizativa))
            {
                areas.Add(new AreaViewModel(area));
            }

            return View(areas);
        }

        //public ActionResult AddArea()
        //{
        //    var data = db.ModelosGuias.ToList();

        //    foreach (var item in data.GroupBy(s=>s.Direccion).OrderBy(s => s.Key))
        //    {
        //        if (!db.Areas.Include(s => s.UnidadOrganizativa).ToList().Any(s => s.Nombre.Trim().ToUpper().Equals(item.First().Direccion.Trim().ToUpper())))
        //        {
        //            var unidad = db.UnidadesOrganizativas.First();
        //            if (unidad != null)
        //            {
        //                db.Areas.Add(new Area
        //                {
        //                    Nombre = item.Key.TrimEnd(),
        //                    UnidadOrganizativaId = unidad.Id
        //                });
        //                db.SaveChanges();
        //            }
        //            else
        //            {
        //                var x = 1;
        //            }

        //        }
        //    }
        //    return RedirectToAction("Index");
        //}
        // GET: /Area/Insertar
        public ActionResult Insertar()
        {
            ViewBag.UnidadOrganizativaId = new SelectList(db.UnidadesOrganizativas, "Id", "Nombre");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insertar([Bind(Include = "Id,Nombre,UnidadOrganizativaId")] Area area)
        {
            if (ModelState.IsValid)
            {

                db.Areas.Add(area);
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "El Área se ha insertado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "El Área no se pudo insertado correctamente.";
                }
                return RedirectToAction("Index");
            }
            var uo = db.UnidadesOrganizativas.Where(u => !db.Areas.Any(a => a.UnidadOrganizativaId == u.Id));
            ViewBag.UnidadOrganizativaId = new SelectList(uo, "Id", "Nombre");
            ViewBag.EntidadId = new SelectList(db.UnidadesOrganizativas, "Id", "Nombre");
            return View("Insertar", area);
        }

        // GET: /Area/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }


            ViewBag.UnidadOrganizativaId = new SelectList(db.UnidadesOrganizativas, "Id", "Nombre", area.UnidadOrganizativaId);
            return View("Editar", area);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,UnidadOrganizativaId")] Area area)
        {
            var areaOld = db.Areas.SingleOrDefault(s => s.Id == area.Id);
            var contenido = db.ContenidoGuias.Where(s => s.Direccion.Equals(areaOld.Nombre)).ToList();
            var modelo = db.ModelosGuias.Where(s => s.Direccion.Equals(areaOld.Nombre));
            foreach (var item in contenido)
            {
                item.Direccion = area.Nombre;
                var cont = db.Entry(item);
                db.ContenidoGuias.Attach(item);
                cont.State = EntityState.Modified;
            }
            foreach (var item in modelo)
            {
                
                item.Direccion = area.Nombre;
                var cont = db.Entry(item);
                db.ModelosGuias.Attach(item);
                cont.State = EntityState.Modified;
            }

            if (ModelState.IsValid)
            {
                areaOld.Nombre = area.Nombre;
                var are = db.Entry(areaOld);
                db.Areas.Attach(areaOld);
                are.State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "El Área se ha editado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "El Área no se pudo editar correctamente.";
                }
                return RedirectToAction("Index");
            }
            ViewBag.UnidadOrganizativaId = new SelectList(db.UnidadesOrganizativas, "Id", "Nombre");
            ViewBag.EntidadId = new SelectList(db.UnidadesOrganizativas, "Id", "Nombre");
            return View("Editar", area);
        }

        // GET: /Trabajador/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }

            if (area is Area)
            {
                return View(area as Area);
            }
            return View(area);
        }

        // POST: /Trabajador/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            Area area = db.Areas.Find(id);
            db.Areas.Remove(area);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Areas(int? id)
        {
            //ViewBag.AreaId = new SelectList(db.Areas.Where(a => a.EntidadId == id), "Id", "Nombre");
            return PartialView("_AreasPartial");
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
