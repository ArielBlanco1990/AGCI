using System;
using AGCI.Models;

namespace AGCI.Models
{
    public class LogCambio
    {
        public int Id { get; set; }

        public string TablaModificada { get; set; }

        public string ValoresAnteriores { get; set; }

        public DateTime Fecha { get; set; }

        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}