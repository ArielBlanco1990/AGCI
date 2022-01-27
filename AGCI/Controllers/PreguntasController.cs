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
    public class PreguntasController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: Preguntas
        public ActionResult Index()
        {
            var preguntas = db.Preguntas.Include(p => p.GrupoPregunta).Include(p => p.Norma);
            return View(preguntas.ToList());
        }

        // GET: Preguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // GET: Preguntas/Create
        public ActionResult Create()
        {
            ViewBag.ComponenteId = new SelectList(db.Componentes, "Descripcion", "Descripcion");
            ViewBag.GrupoPreguntaId = new SelectList(db.GrupoPreguntas, "Id", "Nombre");
            ViewBag.NormaId = new SelectList(db.Normas, "Id", "Nombre");
            ViewBag.LeyId = new SelectList(db.Leyes, "Id", "Nombre");
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CGR,Otros,NoP,NoPreguntas,Numero,Nombre,Responsable,JefeInmediato,Direccion,ComponenteDescripcion,Norma,NormaId,GrupoPreguntaId,LeyId")] Pregunta pregunta, string ComponenteId)
        {
           
            pregunta.ComponenteDescripcion = ComponenteId;
            var norma = db.Normas.SingleOrDefault(s => s.Id == pregunta.NormaId);
            pregunta.NormaName = norma.Nombre;
            if (pregunta.GrupoPreguntaId != null)
            {
                pregunta.NormaId = null;
            }
            if (ModelState.IsValid)
            {
                db.Preguntas.Add(pregunta);
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "La Pregunta se ha insertado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "La Pregunta no se pudo insertar correctamente.";
                }
                return RedirectToAction("Index");
            }
            var comp = db.Componentes.Where(s => s.Descripcion.Equals(pregunta.ComponenteDescripcion)).First();
            ViewBag.ComponenteId = new SelectList(db.Componentes, "Id", "Descripcion", comp);
            ViewBag.NormaId = new SelectList(db.Normas, "Id", "Nombre", pregunta.NormaId);
            ViewBag.GrupoPreguntaId = new SelectList(db.GrupoPreguntas, "Id", "Nombre", pregunta.GrupoPreguntaId);
            ViewBag.LeyId = new SelectList(db.Leyes, "Id", "Nombre", pregunta.LeyId);
            return View(pregunta);
        }

        // GET: Preguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            var comp = db.Componentes.Where(s => s.Descripcion.Equals(pregunta.ComponenteDescripcion)).First();
            ViewBag.ComponenteId = new SelectList(db.Componentes, "Id", "Descripcion", comp);
            ViewBag.NormaId = new SelectList(db.Normas, "Id", "Nombre", pregunta.NormaId);
            ViewBag.GrupoPreguntaId = new SelectList(db.GrupoPreguntas, "Id", "Nombre", pregunta.GrupoPreguntaId);
            ViewBag.LeyId = new SelectList(db.Leyes, "Id", "Nombre", pregunta.LeyId);
            return View(pregunta);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Direccion,ComponenteDescripcion,NormaName,GrupoPreguntaId,NormaId")] Pregunta pregunta, string ComponenteId)
        {
            pregunta.ComponenteDescripcion = ComponenteId;
            var preguntaOld = db.Preguntas.SingleOrDefault(s => s.Id == pregunta.Id);
            var contenido = db.ContenidoGuias.Where(s => s.Nombre.Trim().Equals(preguntaOld.Nombre.Trim())).ToList();
            var modelo = db.ModelosGuias.Where(s => s.Nombre.Trim().Equals(preguntaOld.Nombre.Trim()));
            foreach (var item in contenido)
            {
                item.Nombre = pregunta.Nombre;
                var cont = db.Entry(item);
                db.ContenidoGuias.Attach(item);
                cont.State = EntityState.Modified;
            }
            foreach (var item in modelo)
            {
                item.Nombre = pregunta.Nombre;
                var cont = db.Entry(item);
                db.ModelosGuias.Attach(item);
                cont.State = EntityState.Modified;
            }

            if (ModelState.IsValid)
            {
                preguntaOld.Nombre = pregunta.Nombre;
                var preg = db.Entry(preguntaOld);
                db.Preguntas.Attach(preguntaOld);
                preg.State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var comp = db.Componentes.Where(s => s.Descripcion.Equals(pregunta.ComponenteDescripcion)).First();
            ViewBag.ComponenteId = new SelectList(db.Componentes, "Id", "Descripcion", comp);
            ViewBag.NormaId = new SelectList(db.Normas, "Id", "Nombre", pregunta.NormaId);
            ViewBag.GrupoPreguntaId = new SelectList(db.GrupoPreguntas, "Id", "Nombre", pregunta.GrupoPreguntaId);
            ViewBag.LeyId = new SelectList(db.Leyes, "Id", "Nombre", pregunta.LeyId);
            return View(pregunta);
        }

        // GET: Preguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pregunta pregunta = db.Preguntas.Find(id);
            db.Preguntas.Remove(pregunta);
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
