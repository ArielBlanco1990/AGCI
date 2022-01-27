using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGCI.AuxClasses;
using AGCI.Models;
using AGCI.ViewModels;

namespace AGCI.Controllers
{
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
    public class InicioController : Controller
    {
        private AGCIContext db = new AGCIContext();

        public ActionResult Index()
        {
           
            var estadisticas = new List<EstadisticaViewModel>();
            var guiasX = db.Guias.Include(g => g.Area).Include(g => g.Contenido).Where(s=>s.Año == DateTime.Now.Year && s.Mes == DateTime.Now.Month);
            foreach (var item in guiasX.GroupBy(s=>s.Area))
            {
                var guias = db.Guias.Include(g => g.Area).Include(g => g.Contenido).ToList().SingleOrDefault(s => s.AreaId == item.First().AreaId && s.Año == DateTime.Now.Year && s.Mes == DateTime.Now.Month);
                int D = guias.Contenido.Sum(s => s.Si).Value > 0 ? guias.Contenido.Sum(s => s.Si).Value : 0;
                int F = guias.Contenido.Sum(s => s.No).Value > 0 ? guias.Contenido.Sum(s => s.No).Value : 0;
                int H = guias.Contenido.Sum(s => s.Np).Value > 0 ? guias.Contenido.Sum(s => s.Np).Value : 0;
                int J = D + F;
                int K = D + F + H;
                double Dp = 0;
                double Dn = 0;
                double Dnp = 0;
                if (D==0)
                {
                    Dp = 0;
                }
                else
                {
                    Dp = ((double)D/ (double)J) * 100;
                }
                if (F == 0)
                {
                    Dn = 0;
                }
                else
                {
                    Dn = ((double)F / (double)J) * 100;
                }

                if (H == 0)
                {
                    Dnp = 0;
                }
                else
                {
                    Dnp = ((double)H / (double)K) * 100;
                }

                estadisticas.Add(new EstadisticaViewModel
                {
                    ACTIVIDAD = item.Key.Nombre,
                    POSITIVO_Cant = D,
                    NEGATIVO_Cant = F,
                    NO_PROCEDE_Cant = guias.Contenido.Sum(s => s.Np).Value > 0 ? guias.Contenido.Sum(s => s.Np).Value : 0,
                    POSITIVO_Porc = Math.Round(Dp),
                    NEGATIVO_Porc = Math.Round(Dn),
                    NO_PROCEDE_Porc = Math.Round(Dnp)


                });
            }
            ViewBag.Fecha = ((Mes)DateTime.Now.Month).ToString() + " / " + DateTime.Now.Year;
            return View(estadisticas);
        }

        public ActionResult Desarrollo()
        {
            ViewBag.Message = "Esta opcion esta en desarrollo.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}