using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AGCI.Models
{
  
    public class ModeloGuia
    {
        public int Id { get; set; }
     
        public string CGR { get; set; }
        public string Otros { get; set; }
        public int? NoP { get; set; }
        public double? NoPreguntas { get; set; }
        public int? Numero { get; set; }
        public string Nombre { get; set; }
        public int? Si { get; set; }
        public int? No { get; set; }
        public int? Np { get; set; }
        public string Responsable { get; set; }
        public string JefeInmediato { get; set; }
        public string Direccion { get; set; }
        public string ComponenteDescripcion { get; set; }
        public string Norma { get; set; }
      

    }
}
