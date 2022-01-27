using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGCI.Models;

namespace Agci.Controllers
{
    public class LeyesController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: Leyes
        public ActionResult Index()
        {
            return View(db.Leyes.ToList());
        }

        // GET: Leyes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ley ley = db.Leyes.Find(id);
            if (ley == null)
            {
                return HttpNotFound();
            }
            return View(ley);
        }

        // GET: Leyes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leyes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,FechaVencimiento")] Ley ley)
        {
            if (ModelState.IsValid)
            {
                db.Leyes.Add(ley);
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "La leyse ha insertado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "La ley no se pudo insertar correctamente.";
                }
                return RedirectToAction("Index");
            }

            return View(ley);
        }

        // GET: Leyes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ley ley = db.Leyes.Find(id);
            if (ley == null)
            {
                return HttpNotFound();
            }
            //if (ley.FechaVencimiento != null)
            //{
            //    @ViewBag.Options.Date.To = ley.FechaVencimiento.Value;
            //}
            //else
            //{
            //    @ViewBag.Fecha = null;
            //}
         
            return View(ley);
        }

        // POST: Leyes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,FechaVencimiento")] Ley ley)
        {
            var leyOld = db.Leyes.SingleOrDefault(s => s.Id == ley.Id);
            var contenido = db.ContenidoGuias.Where(s => s.LeyId.Value.Equals(ley.Id)).ToList();
            var modelo = db.ModelosGuias.Where(s => s.CGR.Equals(leyOld.Nombre));
            foreach (var item in contenido)
            {
                item.CGR = ley.Nombre;
                item.FechaDeVencimiento = ley.FechaVencimiento;
                var cont = db.Entry(item);
                db.ContenidoGuias.Attach(item);
                cont.State = EntityState.Modified;
            }
            foreach (var item in modelo)
            {
               
                item.CGR = ley.Nombre;
                var cont = db.Entry(item);
                db.ModelosGuias.Attach(item);
                cont.State = EntityState.Modified;
            }

            if (ModelState.IsValid)
            {
                leyOld.Nombre = ley.Nombre;
                leyOld.FechaVencimiento = ley.FechaVencimiento!=null? ley.FechaVencimiento.Value.Date: ley.FechaVencimiento;
                var norm = db.Entry(leyOld);
                db.Leyes.Attach(leyOld);
                norm.State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "La ley se ha modificado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "La ley no se pudo modificar correctamente.";
                }
                return RedirectToAction("Index");
            }
            
            return View(ley);
        }

        // GET: Leyes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ley ley = db.Leyes.Find(id);
            if (ley == null)
            {
                return HttpNotFound();
            }
            return View(ley);
        }

        // POST: Leyes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ley ley = db.Leyes.Find(id);
            db.Leyes.Remove(ley);
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
