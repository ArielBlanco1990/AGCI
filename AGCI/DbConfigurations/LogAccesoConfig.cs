using System.Data.Entity.ModelConfiguration;
using AGCI.Models;

namespace AGCI.DbConfigurations
{
    public class LogAccesoConfig:EntityTypeConfiguration<LogAcceso>
    {
        public LogAccesoConfig()
        {
            ToTable("AGCI_logs_de_accesos");
            HasRequired(l => l.Usuario).WithMany().HasForeignKey(l => l.UsuarioId).WillCascadeOnDelete(false);
        }
    }
}