using System.Data.Entity;
using System.Linq;

using DevExpress.XtraReports.UI;
using AGCI.Models;
using AGCI.ViewModels;

namespace AGCI.Reportes
{
    public partial class PlanesDeMedidaControlReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PlanesDeMedidaControlReport(int id)
        {
            InitializeComponent();
            var db = new AGCIContext();

            var data = db.Set<Guia>().Include(s => s.Area).Include(s=>s.PlanDeMedidas).SingleOrDefault(s=>s.Id == id);

            DataSource = data.PlanDeMedidas.ToList();

            this.area.Text = data.Area.Nombre;

            //this.numerador.DataBindings.AddRange(new XRBinding[] {
            //new XRBinding("Text", null, "Numerador")});

            this.numero.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Numero")});

            this.causas.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "CausasCondiciones")});

            this.fecha.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "FechaCumplimiento","{0:dd/MM/yyyy}" )});
         

            this.medidas.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Medidas")});

            this.controla.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Controla")});

       

            this.ejecutor.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Ejecutor")});

            this.deficiencias.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "DeficienciasSeñaladas")});



        }

    }
}
