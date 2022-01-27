using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using AGCI.Models;
using AGCI.ViewModels;

namespace AGCI.Controllers
{
    [Authorize]
    public class SeguridadController : Controller
    {
        private readonly AGCIContext _db = new AGCIContext();

        public SeguridadController()
            : this(new UserManager<Usuario>(new UserStore<Usuario>(new AGCIContext())))
        {
        }

        public SeguridadController(UserManager<Usuario> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<Usuario> UserManager { get; private set; }



        //
        // GET: /Usuario/Autenticarse
        [AllowAnonymous]
        public ActionResult Autenticarse(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_Autenticarse");
        }

        //
        // POST: /Usuario/Autenticarse
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Autenticarse(AutenticarseViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.NombreUsuario, model.Contraseña);
                if (user != null)
                {
                    await SignInAsync(user, false);
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Contraseña o nombre de usuario incorrecto.");
            }
            // If we got this far, something failed, redisplay form
            return PartialView("_Autenticarse", model);
        }

        //
        // GET: /Usuario/CambiarContraseña
        [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
        public ActionResult CambiarContraseña(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ExitoCambioContraseña ? "Su contraseña ha sido cambiada correctamente."
                : message == ManageMessageId.ExitoCrearContraseña ? "Su contraseña ha sido definida."
                : message == ManageMessageId.Error ? "Ha ocurrido un error."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("CambiarContraseña");
            return View();
        }

        //
        // POST: /Usuario/CambiarContraseña
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
        public async Task<ActionResult> CambiarContraseña(CambiarContraseñaViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("CambiarContraseña");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.ContraseñaActual, model.ContraseñaNueva);
                    if (result.Succeeded)
                    {
                        TempData["exito"] = ManageMessageId.ExitoCambioContraseña;
                        return RedirectToAction("CambiarContraseña");
                    }
                    AddErrors(result);
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["ContraseñaActual"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.ContraseñaNueva);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("CambiarContraseña", new { Message = ManageMessageId.ExitoCrearContraseña });
                    }
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesAGCI.Administrador)]
        public async Task<ActionResult> RestartPassword(string userName)
        {
          
            await UserManager.RemovePasswordAsync(userName);
            var result = await UserManager.AddPasswordAsync(userName, "A123456-");
          
            if (result.Succeeded)
            {
                TempData["exito"] = ManageMessageId.ExitoCambioContraseña;
                return RedirectToAction("ListaUsuario");
            }
            else
            {
                AddErrors(result);
            }
           
            return RedirectToAction("ListaUsuario");
        }

        //
        // POST: /Usuario/CerrarSesion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CerrarSesion()
        {
            _db.LogsDeAccesos.Add(new LogAcceso() { UsuarioId = User.Identity.GetUserId(), Salida = DateTime.Now });
            AuthenticationManager.SignOut();
            _db.SaveChanges();
            return RedirectToAction("Index", "Inicio");
        }

        [Authorize(Roles = RolesAGCI.Administrador)]
        public ActionResult ListaUsuario()
        {
            var trabajadores = _db.Trabajadores.Where(t => t.Usuario.Roles.Any(r => r.Role.Name == RolesAGCI.Administrador || r.Role.Name == RolesAGCI.Usuario || r.Role.Name == RolesAGCI.Auditor || r.Role.Name == RolesAGCI.Consultor)).ToList();
            return View(trabajadores);
        }

        [Authorize(Roles = RolesAGCI.Administrador)]
        public ActionResult ListaUsuarioAdministracion()
        {
            var usuarios = _db.Users.Where(t => t.Roles.Any(r => r.Role.Name == RolesAGCI.Administrador || r.Role.Name == RolesAGCI.Auditor || r.Role.Name == RolesAGCI.Consultor)).ToList();
            return View(usuarios);
        }



        [Authorize(Roles = RolesAGCI.Administrador)]
        public ActionResult DatosDeUsuario(int? id)
        {
            if (id != null)
            {
                using (var db = new AGCIContext())
                {
                    var trabajador = _db.Trabajadores.Find(id);
                    if (!String.IsNullOrEmpty(trabajador.UsuarioId))
                    {
                        return PartialView("_UsuarioPartial", new UsuarioAGCIViewModel { UsuarioViewModel = new UsuarioViewModel(trabajador.Usuario) });
                    }
                }
                return PartialView("_UsuarioPartial");
            }
            return null;
        }

        [Authorize(Roles = RolesAGCI.Administrador)]
        public ActionResult CrearUsuario()
        {
            //var trabajadores =
            //    _db.Trabajadores.Where(
            //        t =>
            //            !t.Usuario.Roles.Any(
            //                r => r.Role.Name == RolesAGCI.Administrador || r.Role.Name == RolesAGCI.Usuario));
            //ViewBag.TrabajadorId = new SelectList(trabajadores, "Id", "NombreCompleto");

            var roles = new List<dynamic>()
            {
              new { Nombre = RolesAGCI.Administrador},
              new { Nombre = RolesAGCI.Usuario},
              new { Nombre = RolesAGCI.Auditor},
              new { Nombre = RolesAGCI.Consultor}
            };
            ViewBag.Rol = new SelectList(roles, "Nombre", "Nombre");
            return View();
        }

        //
        // POST: /Usuario/CerrarSesion
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesAGCI.Administrador)]
        public async Task<ActionResult> CrearUsuario([Bind(Include = "Id,UsuarioViewModel,Rol")]UsuarioAGCIViewModel usuarioAGCIViewModel)
        {
            if (ModelState.IsValid)
            {
                //var trabajador = _db.Trabajadores.Find(usuarioAGCIViewModel.TrabajadorId);
                var usuarioId = "";
                if (!_db.Users.Any(s=>s.UserName.Equals(usuarioAGCIViewModel.UsuarioViewModel.NombreUsuario)))
                {
                    var user = new Usuario
                    {
                        UserName = usuarioAGCIViewModel.UsuarioViewModel.NombreUsuario,
                        Activo = true,
                        Correo = usuarioAGCIViewModel.UsuarioViewModel.NombreUsuario+"@azumat.cu",
                    };
                    var result = await UserManager.CreateAsync(user, "A123456-");
                    usuarioId = user.Id;
                    
                }
              
                await UserManager.AddToRoleAsync(usuarioId, usuarioAGCIViewModel.Rol);
                TempData["exito"] = ManageMessageId.ExitoCrearUsuario;
                return RedirectToAction("ListaUsuario");
            }
            var roles = new List<dynamic>()
            {
              new { Nombre = RolesAGCI.Administrador},
              new { Nombre = RolesAGCI.Usuario},
               new { Nombre = RolesAGCI.Auditor},
              new { Nombre = RolesAGCI.Consultor}
            };
            ViewBag.Rol = new SelectList(roles, "Nombre", "Nombre", usuarioAGCIViewModel.Rol);
            return View(usuarioAGCIViewModel);
        }

        [Authorize(Roles = RolesAGCI.Administrador)]
        public ActionResult Eliminar(int id)
        {
            var usuario = _db.Trabajadores.Find(id);
            return PartialView("_EliminarUsuarioPartial", usuario);
        }

        [Authorize(Roles = RolesAGCI.Administrador)]
        [HttpPost]
        public ActionResult EliminarConfirmado(int id)
        {
            var usuario = _db.Trabajadores.Find(id);
            if (usuario == null)
            {
                return new HttpNotFoundResult();
            }

            if (usuario.Usuario.Roles.Any(r => r.Role.Name == RolesAGCI.Usuario))
            {
                UserManager.RemoveFromRole(usuario.UsuarioId, RolesAGCI.Usuario);
            }
            if (usuario.Usuario.Roles.Any(r => r.Role.Name == RolesAGCI.Administrador))
            {
                UserManager.RemoveFromRole(usuario.UsuarioId, RolesAGCI.Administrador);
            }
            if (usuario.Usuario.Roles.Any(r => r.Role.Name == RolesAGCI.Auditor))
            {
                UserManager.RemoveFromRole(usuario.UsuarioId, RolesAGCI.Auditor);
            }
            if (usuario.Usuario.Roles.Any(r => r.Role.Name == RolesAGCI.Consultor))
            {
                UserManager.RemoveFromRole(usuario.UsuarioId, RolesAGCI.Consultor);
            }
            TempData["exito"] = "Usuario eliminado correctamente";
            return RedirectToAction("ListaUsuario");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                _db.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(Usuario user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
            _db.LogsDeAccesos.Add(new LogAcceso() { UsuarioId = user.Id, Entrada = DateTime.Now });
            _db.SaveChanges();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ExitoCambioContraseña,
            ExitoCrearContraseña,
            ExitoCrearUsuario,
            ExitoEditarUsuario,
            Error,
            NoModificable
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Inicio");
        }

        #endregion
    }
}