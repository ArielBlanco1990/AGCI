using System.Data.Entity;
using System.Linq;

using DevExpress.XtraReports.UI;
using AGCI.Models;
using AGCI.ViewModels;
using System.Collections.Generic;

namespace AGCI.Reportes
{
    public partial class GuiaAutoControlParamReport : DevExpress.XtraReports.UI.XtraReport
    {
        public GuiaAutoControlParamReport(ParamViewModel param)
        {
            InitializeComponent();
            var db = new AGCIContext();

            var data = from s in db.Guias.Include(s=>s.Area).Include(s => s.Contenido)
                       select s;


            if (param.AreaId != null)
            {
                data = from s in data
                       where s.AreaId == param.AreaId
                       select s;
            }
            if (param.Año != null)
            {
                data = from s in data
                       where s.Año == param.Año
                       select s;
            }

            if (param.Mes != null)
            {
                data = from s in data
                       where s.Mes == param.Mes
                       select s;
            }
         
           

            DataSource = data.ToList();
            xrSubreport1.ReportSource = new ContenidoSubReport();

            this.area.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Area.Nombre")});

            this.mes.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Mes")});

            this.año.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Año")});
                           

        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var lista = (ICollection<ContenidoGuia>)GetCurrentColumnValue("Contenido");
            var report = ((ContenidoSubReport)((XRSubreport)sender).ReportSource);
            if (!(lista == null))
            {
                report.CargarDatos(lista);
            }

            lista = null;
        }
    }
}
