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
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
    public class PlanDeMedidasController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: PlanDeMedidas
        public ActionResult Index()
        {
            var planDeMedida = db.PlanDeMedida.Include(p => p.Guia);
            return View(planDeMedida.ToList());
        }

        // GET: PlanDeMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanDeMedida planDeMedida = db.PlanDeMedida.Find(id);
            if (planDeMedida == null)
            {
                return HttpNotFound();
            }
            return View(planDeMedida);
        }

        // GET: PlanDeMedidas/Create
        public ActionResult Create()
        {
            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id");
            return View();
        }

        // POST: PlanDeMedidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numerador,Numero,DeficienciasSeñaladas,CausasCondiciones,Medidas,Ejecutor,Controla,FechaCumplimiento,GuiaId")] PlanDeMedida planDeMedida)
        {
            if (ModelState.IsValid)
            {
                db.PlanDeMedida.Add(planDeMedida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id", planDeMedida.GuiaId);
            return View(planDeMedida);
        }

        // GET: PlanDeMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanDeMedida planDeMedida = db.PlanDeMedida.Find(id);
            if (planDeMedida == null)
            {
                return HttpNotFound();
            }
            ViewBag.EjecutorId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", planDeMedida.Ejecutor);
            ViewBag.ControlaId = new SelectList(db.Trabajadores, "NombreCompleto", "NombreCompleto", planDeMedida.Controla);
            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id", planDeMedida.GuiaId);
            ViewBag.Guia = planDeMedida.GuiaId;
            return View(planDeMedida);
        }

        // POST: PlanDeMedidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numerador,Numero,DeficienciasSeñaladas,CausasCondiciones,Medidas,Ejecutor,Controla,FechaCumplimiento,GuiaId")] PlanDeMedida planDeMedida, string EjecutorId, string ControlaId)
        {
            planDeMedida.Ejecutor = EjecutorId;
            planDeMedida.Controla = ControlaId;
            if (ModelState.IsValid)
            {
                db.Entry(planDeMedida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Planes","Guias", new {id = planDeMedida.GuiaId });
            }
            ViewBag.GuiaId = new SelectList(db.Guias, "Id", "Id", planDeMedida.GuiaId);
            return View(planDeMedida);
        }

        // GET: PlanDeMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanDeMedida planDeMedida = db.PlanDeMedida.Find(id);
            if (planDeMedida == null)
            {
                return HttpNotFound();
            }
            return View(planDeMedida);
        }

        // POST: PlanDeMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanDeMedida planDeMedida = db.PlanDeMedida.Find(id);
            db.PlanDeMedida.Remove(planDeMedida);
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
