using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGCI.Models
{
    public class Pregunta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string ComponenteDescripcion { get; set; }
        public string NormaName { get; set; }

        public int? GrupoPreguntaId { get; set; }
        public virtual GrupoPregunta GrupoPregunta { get; set; }
        public int? NormaId { get; set; }
        public virtual Norma Norma { get; set; }
        public int? LeyId { get; set; }
        public virtual Ley Leyes { get; set; }
    }
}