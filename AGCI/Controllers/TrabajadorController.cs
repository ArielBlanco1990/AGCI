using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using AGCI.Models;
using AGCI.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AGCI.Controllers
{
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]

    public class TrabajadorController : Controller
    {
        private AGCIContext db = new AGCIContext();

        // GET: /Trabajador/
        public ActionResult Index()
        {
            var trabajadores = db.Trabajadores.Where(t => t.Activo);

            var lista = new List<TrabajadorViewModel>();

            foreach (var trab in db.Trabajadores.Include(t => t.TrabajadorArea).Where(t => t.Activo))
            {
                lista.Add(new TrabajadorViewModel(trab));
            }
            return View(lista);
        }

        // GET: /Trabajador/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajadores.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: /Trabajador/Create
        public ActionResult Insertar()
        {
            ViewBag.Areas = new MultiSelectList(db.Areas, "Id", "Nombre");
            //ViewBag.TrabajadorId = new SelectList(db.Trabajadores, "Id", "NombreCompleto");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insertar(Trabajador trabajador, List<int> Areas)
        {
           
            if (trabajador.UsuarioId!=null)
            {
                if (db.Users.Any(s => s.UserName.Equals(trabajador.UsuarioId)))
                {
                    TempData["error"] = "Ya existe un usuario con ese nombre.";
                    ViewBag.Areas = new MultiSelectList(db.Areas, "Id", "Nombre", trabajador.TrabajadorArea);
                    return View("Insertar", trabajador);
                }
                else
                {
                    var user = new Usuario
                    {
                        UserName = trabajador.UsuarioId,
                        PasswordHash = "AGSN+g9ES3JEV8pg+lJiuDWpfOvzEOlnob3bMpIx768qu+GAteAu/t+fsrGsvPQV+w==",
                        SecurityStamp = "d31f0423-2573-4616-94a7-98d3c8f4bf82",
                        Activo = true,
                        Correo = trabajador.UsuarioId + "@azumat.cu",

                    };
                    user.Roles.Add(new IdentityUserRole() { RoleId = "2" });

                    db.Users.Add(user);

                    trabajador.Usuario = user;
                }
               
            }
           


            if (Areas != null)
            {
                if (Areas.Count() > 0)
                {
                    foreach (var item in Areas)
                    {
                        var area = db.Areas.Find(item);
                        var sp = new TrabajadorArea { AreaId = area.Id, Trabajador = trabajador };
                        trabajador.TrabajadorArea.Add(sp);

                    }
                }
            }
            else
            {
                TempData["notice"] = "El campo área es obligatorio.";
                ViewBag.Areas = new MultiSelectList(db.Areas, "Id", "Nombre", trabajador.TrabajadorArea);
                return View("Insertar", trabajador);
            }
            if (ModelState.IsValid)
            {
                
               
                trabajador.Activo = true;
               
                if (db.Trabajadores.Any(s => s.Ci.Equals(trabajador.Ci)))
                {
                    TempData["error"] = "Ya existe ese trabajador.";
                    ViewBag.Areas = new MultiSelectList(db.Areas, "Id", "Nombre", trabajador.TrabajadorArea);
                    return View("Insertar", trabajador);
                }
                db.Trabajadores.Add(trabajador);
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "El Trabajador se ha insertado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "El Trabajador no se pudo insertar correctamente.";
                }
                return RedirectToAction("Index");
            }

            //ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre", trabajador.AreaId);
            ViewBag.Areas = new MultiSelectList(db.Areas, "Id", "Nombre", trabajador.TrabajadorArea);
            return View("Insertar", trabajador);
        }

        // GET: /Trabajador/Edit/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajadores.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }

            var areas = trabajador.TrabajadorArea.Select(s => s.AreaId);
            ViewBag.Areas = new MultiSelectList(db.Areas, "Id", "Nombre", areas);
            return View("Editar", trabajador);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Trabajador trabajador, List<int> Areas)
        {
         
            ModelState.Remove("OtrasPcs");
            var sol = db.Entry(trabajador);
            db.Trabajadores.Attach(trabajador);
            sol.Collection(s => s.TrabajadorArea).Load();
            trabajador.TrabajadorArea.Clear();


            if (Areas != null && Areas.Count() > 0)
            {
                foreach (var item in Areas)
                {
                    var sp = new TrabajadorArea { TrabajadorId = trabajador.Id, AreaId = item };
                    trabajador.TrabajadorArea.Add(sp);
                }
            }
            else
            {

                TempData["notice"] = "El campo área es obligatorio.";
                ViewBag.Areas = new MultiSelectList(db.Areas, "Id", "Nombre", trabajador.TrabajadorArea);
                return View("Editar", trabajador);

            }
            if (ModelState.IsValid)
            {
                db.Entry(trabajador).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    TempData["exito"] = "El Trabajador se ha editado correctamente.";
                }
                catch (Exception)
                {
                    TempData["error"] = "El Trabajador no se pudo editar correctamente.";
                }
                return RedirectToAction("Index");
            }

          
            ViewBag.Areas = new MultiSelectList(db.Areas, "Id", "Nombre", trabajador.TrabajadorArea);
            return View("Editar", trabajador);
        }

        // GET: /Trabajador/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajadores.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: /Trabajador/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            Trabajador trabajador = db.Trabajadores.Find(id);
            if (trabajador.UsuarioId != "")
            {
                if (db.Users.Any(s => s.UserName.Equals(trabajador.UsuarioId)))
                {
                    db.Users.Remove(trabajador.Usuario);
                }
                
            }
           
            db.Trabajadores.Remove(trabajador);
            try
            {
                db.SaveChanges();
                TempData["exito"] = "El Trabajador se ha eliminado correctamente.";
            }
            catch (Exception ex)
            {
                trabajador.Activo = false;
                db.SaveChanges();

            }
            TempData["error"] = "El Trabajador no se pudo eliminar correctamente.";
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
