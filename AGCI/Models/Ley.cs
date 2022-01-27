using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AGCI.Models
{
    public class Ley
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime? FechaVencimiento { get; set; }
        public virtual ICollection<Pregunta> Preguntas { get; set; }
        public Ley()
        {
            this.Preguntas = new HashSet<Pregunta>();
        }
    }
}