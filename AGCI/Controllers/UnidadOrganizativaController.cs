using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using AGCI.ViewModels;
using AGCI.Models;

namespace AGCI.Controllers
{
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
    public class UnidadOrganizativaController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: /Area/
        public ActionResult Index()
        {
            return View(db.UnidadesOrganizativas.ToList().OrderBy(a => a.Nombre));
        }

        // GET: /Area/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadOrganizativa unidadOrganizativa = db.UnidadesOrganizativas.Find(id);
            if (unidadOrganizativa == null)
            {
                return HttpNotFound();
            }
            return View(unidadOrganizativa);
        }

       
        // GET: /Area/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Area/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombre,")] UnidadOrganizativa unidadOrganizativa)
        {
            if (ModelState.IsValid)
            {
                db.UnidadesOrganizativas.Add(unidadOrganizativa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadOrganizativa);
        }

        public PartialViewResult ListaDeAreas(int id)
        {
            var unidad = db.UnidadesOrganizativas.Find(id);
            var areasDeLaUnidad = new List<AreasEnUnidadViewModel>();
            foreach (var areas in unidad.Areas)
            {
                areasDeLaUnidad.Add(new AreasEnUnidadViewModel() { Areas = areas.Nombre });
            }
            return PartialView("_ListaDeAreasPartial", areasDeLaUnidad.ToList());
        }

       
        // GET: /Area/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadOrganizativa unidadOrganizativa = db.UnidadesOrganizativas.Find(id);
            if (unidadOrganizativa == null)
            {
                return HttpNotFound();
            }


            return View(unidadOrganizativa);
        }

        // POST: /Area/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre")] UnidadOrganizativa unidadOrganizativa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadOrganizativa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadOrganizativa);
        }

        // GET: /Area/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadOrganizativa unidadOrganizativa = db.UnidadesOrganizativas.Find(id);
            if (unidadOrganizativa == null)
            {
                return HttpNotFound();
            }
            return View(unidadOrganizativa);
        }

        // POST: /Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadOrganizativa unidadOrganizativa = db.UnidadesOrganizativas.Find(id);
            db.UnidadesOrganizativas.Remove(unidadOrganizativa);
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
