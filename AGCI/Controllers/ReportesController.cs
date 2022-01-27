using System.Collections.Generic;
using System.Web.Mvc;
using DevExpress.XtraReports.UI;
using AGCI.Reportes;
using AGCI.ViewModels;
using AGCI.Models;
using AGCI.AuxClasses;

namespace AGCI.Controllers
{
    [Authorize(Roles = RolesAGCI.Administrador + "," + RolesAGCI.Usuario + "," + RolesAGCI.Auditor + "," + RolesAGCI.Consultor)]
    public class ReportesController : Controller
    {
        private AGCIContext db = new AGCIContext();

        static Dictionary<string, XtraReport> reports = new Dictionary<string, XtraReport>();

        public ActionResult ReportViewerPartial(string reporteId)
        {
            return PartialView("ReportViewerPartial", reports[reporteId]);
        }
        public ActionResult ExportReportViewer(string reporteId)
        {
            var reporte = reports[reporteId];
            //reports.Remove(reporteId);
            return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(reporte);
        }

        public ActionResult GenerarPlan(int id)
        {
            var report = new PlanesDeMedidaControlReport(id);
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random, report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }
        public ActionResult Estadistica()
        {
            var Meses = new List<dynamic>() {
                new { Id = 1, Nombre = Mes.Enero },
                new { Id = 2, Nombre = Mes.Feberero },
                new { Id = 3, Nombre = Mes.Marzo },
                new { Id = 4, Nombre = Mes.Abril },
                new { Id = 5, Nombre = Mes.Mayo },
                new { Id = 6, Nombre = Mes.Junio },
                new { Id = 7, Nombre = Mes.Julio },
                new { Id = 8, Nombre= Mes.Agosto },
                new { Id = 9, Nombre= Mes.Septiembre },
                new { Id = 10, Nombre = Mes.Octubre },
                new { Id = 11, Nombre= Mes.Noviembre },
                new { Id = 12, Nombre = Mes.Diciembre }
            };
            ViewBag.Mes = new SelectList(Meses, "Id", "Nombre");
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre");
            return View("Estadistica");
        }
        [HttpPost]
        public ActionResult Estadistica(ParamEstViewModel param)
        {
            var report = new EstadisticaReport(param);
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random, report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }

        public ActionResult EstadisticaResumenComponente()
        {
            var Meses = new List<dynamic>() {
                new { Id = 1, Nombre = Mes.Enero },
                new { Id = 2, Nombre = Mes.Feberero },
                new { Id = 3, Nombre = Mes.Marzo },
                new { Id = 4, Nombre = Mes.Abril },
                new { Id = 5, Nombre = Mes.Mayo },
                new { Id = 6, Nombre = Mes.Junio },
                new { Id = 7, Nombre = Mes.Julio },
                new { Id = 8, Nombre= Mes.Agosto },
                new { Id = 9, Nombre= Mes.Septiembre },
                new { Id = 10, Nombre = Mes.Octubre },
                new { Id = 11, Nombre= Mes.Noviembre },
                new { Id = 12, Nombre = Mes.Diciembre }
            };
            ViewBag.Mes = new SelectList(Meses, "Id", "Nombre");
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre");
            return View("EstadisticaResumenComponente");
        }
        [HttpPost]
        public ActionResult EstadisticaResumenComponente(ParamEstViewModel param)
        {
            var report = new EstadisticaResumenComponenteReport(param);
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random, report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }

        public ActionResult GenerarGuia(int id)
        {
            var report = new GuiaAutoControlReport(id);
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random, report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }

        public ActionResult GuiaAutoControl()
        {
            var Meses = new List<dynamic>() {
                new { Id = 1, Nombre = Mes.Enero },
                new { Id = 2, Nombre = Mes.Feberero },
                new { Id = 3, Nombre = Mes.Marzo },
                new { Id = 4, Nombre = Mes.Abril },
                new { Id = 5, Nombre = Mes.Mayo },
                new { Id = 6, Nombre = Mes.Junio },
                new { Id = 7, Nombre = Mes.Julio },
                new { Id = 8, Nombre= Mes.Agosto },
                new { Id = 9, Nombre= Mes.Septiembre },
                new { Id = 10, Nombre = Mes.Octubre },
                new { Id = 11, Nombre= Mes.Noviembre },
                new { Id = 12, Nombre = Mes.Diciembre }
            };
            ViewBag.Mes = new SelectList(Meses, "Id", "Nombre");
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre");
            return View("GuiaAutoControl");
        }
        [HttpPost]
        public ActionResult GuiaAutoControl(ParamViewModel param)
        {
            if (ModelState.IsValid)
            {
                var report = new GuiaAutoControlParamReport(param);
                string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
                reports.Add(random, report);
                ViewData["ReporteId"] = random;
                return View("Plantilla");
            }
            var Meses = new List<dynamic>() {
                new { Id = 1, Nombre = Mes.Enero },
                new { Id = 2, Nombre = Mes.Feberero },
                new { Id = 3, Nombre = Mes.Marzo },
                new { Id = 4, Nombre = Mes.Abril },
                new { Id = 5, Nombre = Mes.Mayo },
                new { Id = 6, Nombre = Mes.Junio },
                new { Id = 7, Nombre = Mes.Julio },
                new { Id = 8, Nombre= Mes.Agosto },
                new { Id = 9, Nombre= Mes.Septiembre },
                new { Id = 10, Nombre = Mes.Octubre },
                new { Id = 11, Nombre= Mes.Noviembre },
                new { Id = 12, Nombre = Mes.Diciembre }
            };
            ViewBag.Meses = new SelectList(Meses, "Id", "Nombre", param.Mes);
            ViewBag.AreaId = new SelectList(db.Areas, "Id", "Nombre", param.AreaId);
            return View("VisitasEnPeriodo");
        }
    }
}