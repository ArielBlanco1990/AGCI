using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AGCI.Models;
using Newtonsoft.Json;

namespace Agci.Controllers
{
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
    public class NormasController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: Normas
        public ActionResult Index()
        {
            var normas = db.Normas.Include(n => n.Componente);
            return View(normas.ToList());
        }

       


        // GET: Normas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Norma norma = db.Normas.Find(id);
            if (norma == null)
            {
                return HttpNotFound();
            }
            return View(norma);
        }

        // GET: Normas/Create
        public ActionResult Create()
        {
            ViewBag.ComponenteId = new SelectList(db.Componentes, "Id", "Nombre");
            return View();
        }

        // POST: Normas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,ComponenteId")] Norma norma)
        {
            if (ModelState.IsValid)
            {
                db.Normas.Add(norma);
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "La Norma se ha insertado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "La Norma no se pudo insertar correctamente.";
                }
                return RedirectToAction("Index");
            }

            ViewBag.ComponenteId = new SelectList(db.Componentes, "Id", "Nombre", norma.ComponenteId);
            return View(norma);
        }
        // GET: GrupoPreguntas/Create
        public ActionResult CreateGrupo(int id)
        {
            ViewBag.NormaId = id;
            return View();
        }

        // POST: GrupoPreguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGrupo([Bind(Include = "Id,Nombre,Descripcion,NormaId")] GrupoPregunta grupoPregunta)
        {
            if (ModelState.IsValid)
            {
                db.GrupoPreguntas.Add(grupoPregunta);
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "El Grupo de Preguntas se ha insertado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "El Grupo de Preguntas no se pudo insertar correctamente.";
                }
                return RedirectToAction("Index");
            }

            ViewBag.NormaId = grupoPregunta.NormaId;
            return View(grupoPregunta);
        }


        // GET: Normas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Norma norma = db.Normas.Find(id);
            if (norma == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComponenteId = new SelectList(db.Componentes, "Id", "Nombre", norma.ComponenteId);
       
            return View(norma);
        }

        // POST: Normas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,ComponenteId")] Norma norma)
        {
           
            var normaOld = db.Normas.SingleOrDefault(s=>s.Id== norma.Id);
            var contenido = db.ContenidoGuias.Where(s => s.NormaName.Equals(normaOld.Nombre)).ToList();
            var modelo = db.ModelosGuias.Where(s => s.Norma.Equals(normaOld.Nombre));
            foreach (var item in contenido)
            {
                item.NormaName = norma.Nombre;
                if (item.Tipo.Equals("Norma"))
                {
                    item.Nombre = norma.Nombre;
                }
                var cont = db.Entry(item);
                db.ContenidoGuias.Attach(item);
                cont.State = EntityState.Modified;
            }
            foreach (var item in modelo)
            {
                if (item.Nombre.Equals(item.Norma))
                {
                    item.Nombre = norma.Nombre;
                }
                item.Norma = norma.Nombre;
                var cont = db.Entry(item);
                db.ModelosGuias.Attach(item);
                cont.State = EntityState.Modified;
            }
          
            if (ModelState.IsValid)
            {
                normaOld.Nombre = norma.Nombre;
                var norm = db.Entry(normaOld);
                db.Normas.Attach(normaOld);
                norm.State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComponenteId = new SelectList(db.Componentes, "Id", "Nombre", norma.ComponenteId);
            return View(norma);
        }

        // GET: Normas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Norma norma = db.Normas.Find(id);
            if (norma == null)
            {
                return HttpNotFound();
            }
            return View(norma);
        }

        // POST: Normas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Norma norma = db.Normas.Find(id);
            db.Normas.Remove(norma);
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
