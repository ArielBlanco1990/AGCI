using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AGCI.Models;

namespace AGCI.Controllers
{
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
    public class EstadisticasController : Controller
    {
        private AGCIContext db = new AGCIContext();

        //
        // GET: /Estadisticas/
        public ActionResult Index()
        {
            //var laMasMejorArea =
            //    db.VisitasNacionales.GroupBy(v => v.Trabajador.PuestoDeTrabajo.UnidadOrganizativa).Select( p => p);

            //var promedio = db.VisitasNacionales.GroupBy(v => v.Fecha.Month).Average(p => p.Count());

            //ViewBag.Area = laMasMejorArea.Key.Nombre;
            //ViewBag.Visitas = laMasMejorArea.Count();
            //ViewBag.Promedio = promedio.ToString("0.00");
            return View();
        }
	}
}