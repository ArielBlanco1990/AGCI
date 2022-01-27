using AGCI.Models;
using AGCI.AuxClasses;
using System.ComponentModel.DataAnnotations;

namespace AGCI.ViewModels
{
    public class EstadisticaViewModel
    {
        //public int No { get; set; }
        public string ACTIVIDAD { get; set; }
        [Display(Name = "POSITIVO")]
        public int POSITIVO_Cant { get; set; }
        [Display(Name = "%")]
        public double POSITIVO_Porc { get; set; }
        [Display(Name = "NEGATIVO")]
        public int NEGATIVO_Cant { get; set; }
        [Display(Name = "%")]
        public double NEGATIVO_Porc { get; set; }
        [Display(Name = "NO PROCEDE")]
        public int NO_PROCEDE_Cant { get; set; }
        [Display(Name = "%")]
        public double NO_PROCEDE_Porc { get; set; }
        public int Plan { get; set; }
        public int Dif { get; set; }
        public int Dos { get; set; }
        public int Tres { get; set; }


    }
}