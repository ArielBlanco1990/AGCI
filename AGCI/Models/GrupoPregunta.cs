using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AGCI.Models
{
    public class GrupoPregunta
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
    
        public string Descripcion { get; set; }
        [Display(Name = "Norma")]
        public int NormaId { get; set; }
        public virtual Norma Norma { get; set; }

        public virtual ICollection<Pregunta> Preguntas { get; set; }
        public GrupoPregunta()
        {
            this.Preguntas = new HashSet<Pregunta>();
        }
    }
}