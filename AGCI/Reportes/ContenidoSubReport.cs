using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.PLinq.Helpers;
using DevExpress.XtraReports.UI;
using AGCI.Models;

namespace AGCI.Reportes
{
    public partial class ContenidoSubReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ContenidoSubReport()
        {
            InitializeComponent();
        }

        public void CargarDatos(ICollection<ContenidoGuia> contenido)
        {

            DataSource = contenido.ToList();

            this.cgrS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "CGR")});

            this.otrosS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "Otros")});

            this.NopS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "NoP")});

            this.NoPregS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "NoPreguntas")});

            this.guiaS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "Nombre")});

            this.Ss.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "Si")});

            this.Ns.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "No")});

            this.NpS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "Np")});

            this.responsableS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "Responsable")});

            this.jefeS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "JefeInmediato")});

            this.areaS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "Direccion")});
            this.componenteS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComponenteDescripcion")});
            this.normaS.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[]{
                new DevExpress.XtraReports.UI.XRBinding("Text", null, "NormaName")});
        }


    }
}
