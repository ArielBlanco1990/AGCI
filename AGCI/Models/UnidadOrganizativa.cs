using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AGCI.AuxClasses;

namespace AGCI.Models
{
    

    public class UnidadOrganizativa
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Areas")]
        public virtual ICollection<Area> Areas { get; set; }

        public bool Activa { get; set; }

        public UnidadOrganizativa()
        {
            Areas = new HashSet<Area>();
        }

        [NotMapped]
        public string Detalle
        {
            get { return "[" + Codigo + "] " + Nombre; }
        }

     

    }
}

