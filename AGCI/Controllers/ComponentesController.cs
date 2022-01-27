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
    public class ComponentesController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: Componentes
        public ActionResult Index()
        {
            var componentes = db.Componentes;
            return View(componentes.ToList());
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Componente componente = db.Componentes.Find(id);
            if (componente == null)
            {
                return HttpNotFound();
            }
            return View(componente);
        }

        // GET: Componentes/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas.OrderBy(s => s.Nombre), "Id", "Nombre");
            return View();
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Si,No,Np,Descripcion,AreaId")] Componente componente)
        {
            if (ModelState.IsValid)
            {
                db.Componentes.Add(componente);
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "El Componente se ha insertado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "El Componente no se pudo insertar correctamente.";
                }
                return RedirectToAction("Index");
            }

            return View(componente);
        }

        // GET: Normas/Create
        public ActionResult CreateNorma(int id)
        {
            ViewBag.ComponenteId = id;
            return View();
        }

        // POST: Normas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNorma([Bind(Include = "Id,Nombre,ComponenteId")] Norma norma)
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

            ViewBag.ComponenteId = norma.ComponenteId;
            return View(norma);
        }
        public ActionResult AddComponents()
        {
            var data = db.ModelosGuias.ToList().Where(s =>
            s.Nombre.Contains("COMPONENTE") &&
            s.CGR == null &&
            s.Numero == null

            );

            foreach (var item in data.OrderBy(s => s.Direccion))
            {
                if (!db.Componentes.ToList().Any(s => s.Nombre.Trim().ToUpper().Equals(item.Nombre.Trim().ToUpper())))
                {

                    db.Componentes.Add(new Componente
                    {
                        Nombre = item.Nombre.TrimEnd(),
                        Descripcion = item.ComponenteDescripcion.TrimEnd()
                    });

                    db.SaveChanges();


                }
            }
            return RedirectToAction("Index");
        }
        // GET: Componentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Componente componente = db.Componentes.Find(id);
            if (componente == null)
            {
                return HttpNotFound();
            }
          
            return View(componente);
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Si,No,Np,Descripcion,AreaId")] Componente componente)
        {
            var componenteOld = db.Componentes.SingleOrDefault(s => s.Id == componente.Id);
            var contenido = db.ContenidoGuias.Where(s => s.ComponenteDescripcion.Equals(componenteOld.Descripcion)).ToList();
            var modelo = db.ModelosGuias.Where(s => s.ComponenteDescripcion.Equals(componenteOld.Descripcion));
            foreach (var item in contenido)
            {
                item.ComponenteDescripcion = componente.Descripcion;
                if (item.Tipo.Equals("Componente"))
                {
                    item.Nombre = componente.Nombre;
                }
                var cont = db.Entry(item);
                db.ContenidoGuias.Attach(item);
                cont.State = EntityState.Modified;
            }
            foreach (var item in modelo)
            {
                if (item.Nombre.Trim().Equals(componenteOld.Nombre.Trim()))
                {
                    item.Nombre = componente.Nombre;
                }
                item.ComponenteDescripcion = componente.Descripcion;
                var cont = db.Entry(item);
                db.ModelosGuias.Attach(item);
                cont.State = EntityState.Modified;
            }

            if (ModelState.IsValid)
            {
                componenteOld.Nombre = componente.Nombre;
                componenteOld.Descripcion = componente.Descripcion;
                var comp = db.Entry(componenteOld);
                db.Componentes.Attach(componenteOld);
                comp.State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
          
            return View(componente);
        }

        // GET: Componentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Componente componente = db.Componentes.Find(id);
            if (componente == null)
            {
                return HttpNotFound();
            }
            return View(componente);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Componente componente = db.Componentes.Find(id);
            db.Componentes.Remove(componente);
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
