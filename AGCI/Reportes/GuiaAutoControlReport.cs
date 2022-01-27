using System.Data.Entity;
using System.Linq;

using DevExpress.XtraReports.UI;
using AGCI.Models;
using AGCI.ViewModels;

namespace AGCI.Reportes
{
    public partial class GuiaAutoControlReport : DevExpress.XtraReports.UI.XtraReport
    {
        public GuiaAutoControlReport(int id)
        {
            InitializeComponent();
            var db = new AGCIContext();

            var data = db.Set<Guia>().Include(s=>s.Contenido).SingleOrDefault(s=>s.Id == id).Contenido;

            DataSource = data.ToList();
          
            this.cgr.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "CGR")});

            this.otros.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Otros")});

            this.NoPreg.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "NoPreguntas")});

            this.S.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Si")});

            this.NO.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "No")});

            this.NP.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Np")});

            this.Norma.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "NormaName")});

            this.Guia.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Nombre")});

            this.Responsable.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Responsable")});

            this.Direccion.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Direccion")});

            this.Componente.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "ComponenteDescripcion")});

            this.Jefe.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "JefeInmediato")});

            this.Nop.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "Numero")});



        }

    }
}
