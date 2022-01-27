using AGCI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AGCI.Models
{
    
    public class Guia
    {
        public int Id { get; set; }
        public ICollection<ContenidoGuia> Contenido { get; set; }
        [Display(Name = "Área")]
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        [Required]
        public int Año { get; set; }
        [Required]
        public int Mes { get; set; }
        public virtual ICollection<PlanDeMedida> PlanDeMedidas { get; set; }
        public Guia()
        {
            this.Contenido = new HashSet<ContenidoGuia>();
            this.PlanDeMedidas = new HashSet<PlanDeMedida>();
        }


        [NotMapped]
        public string Numerador
        {
            get { return Año + "-" + Mes + "-" + Area.Nombre; }
        }

    }
}
