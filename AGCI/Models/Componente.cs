using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGCI.Models
{
    public class Componente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }


        public virtual ICollection<Norma> Normas { get; set; }
        public virtual ICollection<ContenidoGuia> ContenidoGuias { get; set; }
        public Componente()
        {
            this.Normas = new HashSet<Norma>();
            this.ContenidoGuias = new HashSet<ContenidoGuia>();
        }

    }
}