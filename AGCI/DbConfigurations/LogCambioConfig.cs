using System.Data.Entity.ModelConfiguration;
using AGCI.Models;

namespace AGCI.DbConfigurations
{
    public class LogCambioConfig:EntityTypeConfiguration<LogCambio>
    {
        public LogCambioConfig()
        {
            ToTable("AGCI_logs_de_cambios");
            HasRequired(l => l.Usuario).WithMany().HasForeignKey(l => l.UsuarioId).WillCascadeOnDelete(false);
        }
    }
}