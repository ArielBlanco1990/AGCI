using System;

namespace AGCI.Models
{
    public class LogDeAcceso
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public DateTime? Fecha { get; set; }

        public TipoDeAcceso TipoDeAcceso { get; set; }
    }
}