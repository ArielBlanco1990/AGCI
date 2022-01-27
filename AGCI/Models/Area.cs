using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGCI.Models
{
    [Table("AGCI_areas")]
    public class Area
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Entidad")]
        public int UnidadOrganizativaId { get; set; }

        public virtual UnidadOrganizativa UnidadOrganizativa { get; set; }
        public virtual ICollection<Guia> Guias { get; set; }

        public virtual ICollection<TrabajadorArea> TrabajadorArea { get; set; }
        public virtual ICollection<Componente> Componente { get; set; }

     
        public Area()
        {
            this.TrabajadorArea = new HashSet<TrabajadorArea>();
            this.Componente = new HashSet<Componente>();
            this.Guias = new HashSet<Guia>();
        }

        public string Descripcion { get { return UnidadOrganizativa.Nombre; } }
    }
}