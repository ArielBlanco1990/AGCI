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
    public partial class EstadisticaResumenComponenteReport : DevExpress.XtraReports.UI.XtraReport
    {
        public EstadisticaResumenComponenteReport(ParamEstViewModel param)
        {
            InitializeComponent();
            var db = new AGCIContext();

            var estadisticas = new List<EstadisticaViewModel>();

            int año = DateTime.Now.Year;
            if (param.Año > 0)
            {
                año = param.Año;
            }

            
            var data = db.Componentes.Include(s => s.Normas);
            var dataCont = db.ContenidoGuias.Include(s=>s.Componente).Include(s=>s.Norma).Include(s=>s.Guia).Where(s=>s.Guia.Año == año);
            int DT = 0;
            int FT = 0;
            int HT = 0;
            int NpCantT = 0;

            foreach (var item in data)
            {
                var guiasT = db.Guias.Include(g => g.Area).Include(g => g.Contenido).ToList().Where(s => s.Año == año);
                int D = 0;
                int F = 0;
                int H = 0;
                int NpCant = 0;
                foreach (var guias in guiasT)
                {
                    D = D + (guias.Contenido.Where(s => s.ComponenteId == item.Id).Sum(s => s.Si).Value > 0 ? guias.Contenido.Where(s => s.ComponenteId == item.Id).Sum(s => s.Si).Value : 0);
                    F = F + (guias.Contenido.Where(s => s.ComponenteId == item.Id).Sum(s => s.No).Value > 0 ? guias.Contenido.Where(s => s.ComponenteId == item.Id).Sum(s => s.No).Value : 0);
                    H = H + (guias.Contenido.Where(s => s.ComponenteId == item.Id).Sum(s => s.Np).Value > 0 ? guias.Contenido.Where(s => s.ComponenteId == item.Id).Sum(s => s.Np).Value : 0);
                    NpCant = NpCant + (guias.Contenido.Where(s => s.ComponenteId == item.Id).Sum(s => s.Np).Value > 0 ? guias.Contenido.Where(s => s.ComponenteId == item.Id).Sum(s => s.Np).Value : 0);
                }
               
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
                    ACTIVIDAD = item.Nombre,
                    POSITIVO_Cant = D,
                    NEGATIVO_Cant = F,
                    NO_PROCEDE_Cant = NpCant,
                    POSITIVO_Porc = Math.Round(Dp),
                    NEGATIVO_Porc = Math.Round(Dn),
                    NO_PROCEDE_Porc = Math.Round(Dnp)
                });

                DT = DT + D;
                FT = FT + F;
                HT = HT + H;
                NpCantT = NpCantT + NpCant;

                foreach (var norma in db.Normas.Where(s => s.ComponenteId == item.Id))
                {
                    int D2 = 0;
                    int F2 = 0;
                    int H2 = 0;
                    int NpCant2 = 0;
                    foreach (var guias in guiasT)
                    {
                        D2 = D2 + (guias.Contenido.Where(s => s.ComponenteId == item.Id && s.NormaId == norma.Id).Sum(s => s.Si).Value > 0 ? guias.Contenido.Where(s => s.ComponenteId == item.Id && s.NormaId == norma.Id).Sum(s => s.Si).Value : 0);
                        F2 = F2 + (guias.Contenido.Where(s => s.ComponenteId == item.Id && s.NormaId == norma.Id).Sum(s => s.No).Value > 0 ? guias.Contenido.Where(s => s.ComponenteId == item.Id && s.NormaId == norma.Id).Sum(s => s.No).Value : 0);
                        H2 = H2 + (guias.Contenido.Where(s => s.ComponenteId == item.Id && s.NormaId == norma.Id).Sum(s => s.Np).Value > 0 ? guias.Contenido.Where(s => s.ComponenteId == item.Id && s.NormaId == norma.Id).Sum(s => s.Np).Value : 0);
                        NpCant2 = NpCant2 + (guias.Contenido.Where(s => s.ComponenteId == item.Id && s.NormaId == norma.Id).Sum(s => s.Np).Value > 0 ? guias.Contenido.Where(s => s.ComponenteId == item.Id && s.NormaId == norma.Id).Sum(s => s.Np).Value : 0);
                    }

                    int J2 = D2 + F2;
                    int K2 = D2 + F2 + H2;
                    double Dp2 = 0;
                    double Dn2 = 0;
                    double Dnp2 = 0;
                    if (D2 == 0)
                    {
                        Dp2 = 0;
                    }
                    else
                    {
                        Dp2 = ((double)D2 / (double)J2) * 100;
                    }
                    if (F2 == 0)
                    {
                        Dn2 = 0;
                    }
                    else
                    {
                        Dn2 = ((double)F2 / (double)J2) * 100;
                    }

                    if (H2 == 0)
                    {
                        Dnp2 = 0;
                    }
                    else
                    {
                        Dnp2 = ((double)H2 / (double)K2) * 100;
                    }

                    estadisticas.Add(new EstadisticaViewModel
                    {
                        ACTIVIDAD = norma.Nombre,
                        POSITIVO_Cant = D2,
                        NEGATIVO_Cant = F2,
                        NO_PROCEDE_Cant = NpCant2,
                        POSITIVO_Porc = Math.Round(Dp2),
                        NEGATIVO_Porc = Math.Round(Dn2),
                        NO_PROCEDE_Porc = Math.Round(Dnp2)
                    });
                }
            }

           
          
            this.fecha.Text =  DateTime.Now.Year.ToString();

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

            this.TotalP.Text = DT.ToString();
            this.TotalN.Text = FT.ToString();
            this.TotalNp.Text = NpCantT.ToString();

            int J3 = DT + FT;
            int K3 = DT + FT + HT;
            double Dp3 = 0;
            double Dn3 = 0;
            double Dnp3 = 0;
            if (DT == 0)
            {
                Dp3 = 0;
            }
            else
            {
                Dp3 = ((double)DT / (double)J3) * 100;
            }
            if (FT == 0)
            {
                Dn3 = 0;
            }
            else
            {
                Dn3 = ((double)FT / (double)J3) * 100;
            }

            if (HT == 0)
            {
                Dnp3 = 0;
            }
            else
            {
                Dnp3 = ((double)HT / (double)K3) * 100;
            }

            this.Ppor.Text = Math.Round(Dp3).ToString();
            this.Npor.Text = Math.Round(Dn3).ToString();
            this.Nppro.Text = Math.Round(Dnp3).ToString();

        }


    }
}
