using System.Data.Entity;
using System.Linq;

using DevExpress.XtraReports.UI;
using AGCI.Models;
using AGCI.ViewModels;
using System.Collections.Generic;
using System;
using AGCI.AuxClasses;

namespace AGCI.Reportes
{
    public partial class EstadisticaReport : DevExpress.XtraReports.UI.XtraReport
    {
        public EstadisticaReport(ParamEstViewModel param)
        {
            InitializeComponent();
            var db = new AGCIContext();

            var estadisticas = new List<EstadisticaViewModel>();

            var data = from s in db.Guias.Include(s => s.Area).Include(s => s.Contenido)
                       select s;


            if (param.AreaId != null)
            {
                data = from s in data
                       where s.AreaId == param.AreaId
                       select s;
            }
            if (param.Año != 0)
            {
                data = from s in data
                       where s.Año == param.Año
                       select s;
            }

            if (param.Mes != 0)
            {
                data = from s in data
                       where s.Mes == param.Mes
                       select s;
            }



           
            var guiasX = data.Include(g => g.Area).Include(g => g.Contenido);
            foreach (var item in guiasX.GroupBy(s => s.Area))
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
                if (D == 0)
                {
                    Dp = 0;
                }
                else
                {
                    Dp = ((double)D / (double)J) * 100;
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
            this.fecha.Text = ((Mes)DateTime.Now.Month).ToString() + " / " + DateTime.Now.Year;

            //var data = db.Set<Guia>().Include(s=>s.Contenido).SingleOrDefault(s=>s.Id == id).Contenido;


            DataSource = estadisticas.ToList();
          
         

            this.actividad.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "ACTIVIDAD")});


            this.positivo.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "POSITIVO_Cant")});

            this.porcNP.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "NO_PROCEDE_Porc")});

          
            this.porcP.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "POSITIVO_Porc")});

            this.proN.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "NEGATIVO_Porc")});

            this.nop.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "NO_PROCEDE_Cant")});

            this.negativo.DataBindings.AddRange(new XRBinding[] {
            new XRBinding("Text", null, "NEGATIVO_Cant")});

         



        }

    }
}
