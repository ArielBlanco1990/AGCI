using System;
using AGCI.Models;

namespace AGCI.Models
{
    public class LogAcceso
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public DateTime? Entrada { get; set; }

        public DateTime? Salida { get; set; }
    }
}