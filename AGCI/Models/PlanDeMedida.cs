using AGCI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AGCI.Models
{
   
    public class PlanDeMedida
    {
        public int Id { get; set; }
        public int Numerador { get; set; }
        [Display(Name = "Número")]
        public double? Numero { get; set; }
        [Display(Name = "Deficiencias Señaladas")]
        public string DeficienciasSeñaladas { get; set; }
        [Display(Name = "Causas y Condiciones")]
        public string CausasCondiciones { get; set; }
        public string Medidas { get; set; }
        public string Ejecutor { get; set; }
        public string Controla { get; set; }
        [Display(Name = "Fecha de cumplimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCumplimiento { get; set; }
        public int GuiaId { get; set; }
        public virtual Guia Guia { get; set; }

    }
}