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
    public class GrupoPreguntasController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: GrupoPreguntas
        public ActionResult Index()
        {
            var grupoPreguntas = db.GrupoPreguntas.Include(g => g.Norma).Include(g => g.Norma.Componente);
            return View(grupoPreguntas.ToList());
        }

        // GET: GrupoPreguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoPregunta grupoPregunta = db.GrupoPreguntas.Find(id);
            if (grupoPregunta == null)
            {
                return HttpNotFound();
            }
            return View(grupoPregunta);
        }

        // GET: GrupoPreguntas/Create
        public ActionResult Create()
        {
            ViewBag.NormaId = new SelectList(db.Normas, "Id", "Nombre");
            return View();
        }

        // POST: GrupoPreguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,NormaId")] GrupoPregunta grupoPregunta)
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

            ViewBag.NormaId = new SelectList(db.Normas, "Id", "Nombre", grupoPregunta.NormaId);
            return View(grupoPregunta);
        }

        // GET: Preguntas/Create
        public ActionResult CreatePregunta(int id)
        {
            ViewBag.GrupoPreguntaId = id;
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePregunta([Bind(Include = "Id,CGR,Otros,NoP,NoPreguntas,Numero,Nombre,Responsable,JefeInmediato,Direccion,ComponenteDescripcion,Norma,NormaId,GrupoPreguntaId")] Pregunta pregunta)
        {
            var grupo = db.GrupoPreguntas.Include(s=>s.Norma).Include(s=>s.Norma.Componente).SingleOrDefault(s => s.Id == pregunta.GrupoPreguntaId);
            pregunta.NormaId = grupo.NormaId;
            pregunta.ComponenteDescripcion = grupo.Norma.Componente.Descripcion;
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
            ViewBag.GrupoPreguntaId = pregunta.GrupoPreguntaId;
            return View(pregunta);
        }


        // GET: GrupoPreguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoPregunta grupoPregunta = db.GrupoPreguntas.Find(id);
            if (grupoPregunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.NormaId = new SelectList(db.Normas, "Id", "Nombre", grupoPregunta.NormaId);
            return View(grupoPregunta);
        }

        // POST: GrupoPreguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,NormaId")] GrupoPregunta grupoPregunta)
        {

            var grupoPreguntaOld = db.GrupoPreguntas.SingleOrDefault(s => s.Id == grupoPregunta.Id);
            var contenido = db.ContenidoGuias.Where(s => s.Nombre.Trim().Equals(grupoPreguntaOld.Nombre.Trim())).ToList();
            var modelo = db.ModelosGuias.Where(s => s.Nombre.Trim().Equals(grupoPreguntaOld.Nombre.Trim()));
            foreach (var item in contenido)
            {
                item.Nombre = grupoPregunta.Nombre;
                var cont = db.Entry(item);
                db.ContenidoGuias.Attach(item);
                cont.State = EntityState.Modified;
            }
            foreach (var item in modelo)
            {
                item.Nombre = grupoPregunta.Nombre;
                var cont = db.Entry(item);
                db.ModelosGuias.Attach(item);
                cont.State = EntityState.Modified;
            }

            if (ModelState.IsValid)
            {
                grupoPreguntaOld.Nombre = grupoPregunta.Nombre;
                grupoPreguntaOld.NormaId = grupoPregunta.NormaId;
                var grup = db.Entry(grupoPreguntaOld);
                db.GrupoPreguntas.Attach(grupoPreguntaOld);
                grup.State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NormaId = new SelectList(db.Normas, "Id", "Nombre", grupoPregunta.NormaId);
            return View(grupoPregunta);
        }

        // GET: GrupoPreguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoPregunta grupoPregunta = db.GrupoPreguntas.Find(id);
            if (grupoPregunta == null)
            {
                return HttpNotFound();
            }
            return View(grupoPregunta);
        }

        // POST: GrupoPreguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoPregunta grupoPregunta = db.GrupoPreguntas.Find(id);
            db.GrupoPreguntas.Remove(grupoPregunta);
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
