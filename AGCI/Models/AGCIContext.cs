using System.Data.Entity;
using AGCI.DbConfigurations;
using AGCI.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AGCI.Models
{
    public class AGCIContext : IdentityDbContext<Usuario>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Configurations.Add(new TrabajadorConfig());
            modelBuilder.Configurations.Add(new UnidadOrganizativaConfig());
          
            modelBuilder.Configurations.Add(new LogAccesoConfig());
            modelBuilder.Configurations.Add(new LogCambioConfig());
            modelBuilder.Entity<TrabajadorArea>().HasKey(s => new { s.TrabajadorId, s.AreaId });
            //Configuraciones generales
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AGCIContext>() );
            base.OnModelCreating(modelBuilder);
        }

        public AGCIContext()
            : base("name=ErpConnection")
        {
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public AGCIContext(string config)
            : base(config)
        {

        }


        public DbSet<AGCI.Models.Pregunta> Preguntas { get; set; }
        public DbSet<AGCI.Models.Ley> Leyes { get; set; }
        public DbSet<AGCI.Models.Norma> Normas { get; set; }
        public DbSet<AGCI.Models.GrupoPregunta> GrupoPreguntas { get; set; }
        public DbSet<AGCI.Models.Componente> Componentes { get; set; }
        public DbSet<AGCI.Models.Trabajador> Trabajadores { get; set; }
        public DbSet<AGCI.Models.TrabajadorArea> TrabajadorArea { get; set; }
        public DbSet<UnidadOrganizativa> UnidadesOrganizativas { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<LogAcceso> LogsDeAccesos { get; set; }
        public DbSet<LogCambio> LogsDeCambios { get; set; }
        public DbSet<Guia> Guias { get; set; }
        public DbSet<ModeloGuia> ModelosGuias { get; set; }
        public DbSet<ContenidoGuia> ContenidoGuias { get; set; }
        public DbSet<PlanDeMedida> PlanDeMedida { get; set; }




    }
}
