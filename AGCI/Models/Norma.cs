using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AGCI.Models
{
    public class Norma
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Componente")]
        public int ComponenteId { get; set; }
        public virtual Componente Componente { get; set; }
        public virtual ICollection<GrupoPregunta> GrupoPreguntas { get; set; }
        public virtual ICollection<Pregunta> Preguntas { get; set; }
        public Norma()
        {
            this.GrupoPreguntas = new HashSet<GrupoPregunta>();
            this.Preguntas = new HashSet<Pregunta>();
        }

    }
}