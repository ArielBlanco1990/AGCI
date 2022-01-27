using AGCI.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace AGCI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AGCIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AGCIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Roles.AddOrUpdate(
                  p => p.Id,
                  new IdentityRole() { Id = "1", Name = RolesAGCI.Administrador },
                  new IdentityRole() { Id = "2", Name = RolesAGCI.Usuario },
                  new IdentityRole() { Id = "3", Name = RolesAGCI.Consultor },
                  new IdentityRole() { Id = "4", Name = RolesAGCI.Auditor }
                );

            context.Users.AddOrUpdate(
                  p => p.Id,
                  new Usuario { Id = "1", UserName = "administrador", PasswordHash = "AIlw/bn9HUw29xFQ2o6Iyw8LNbWNQxS6N7wIJL4j3+RRD4v2Vc4too4U7uwSzsBXcQ==", SecurityStamp = "d31f0423-2573-4616-94a7-98d3c8f4bf82", Activo = true, Correo = "administrador@azumat.cu", Roles = { new IdentityUserRole() { UserId = "1", RoleId = "1" } } },
                  new Usuario { Id = "2", UserName = "usuario", PasswordHash = "AIlw/bn9HUw29xFQ2o6Iyw8LNbWNQxS6N7wIJL4j3+RRD4v2Vc4too4U7uwSzsBXcQ==", SecurityStamp = "d31f0423-2573-4616-94a7-98d3c8f4bf81", Activo = true, Correo = "usuario@azumat.cu", Roles = { new IdentityUserRole() { UserId = "2", RoleId = "2" } } },
                  new Usuario { Id = "3", UserName = "consultor", PasswordHash = "AIlw/bn9HUw29xFQ2o6Iyw8LNbWNQxS6N7wIJL4j3+RRD4v2Vc4too4U7uwSzsBXcQ==", SecurityStamp = "d31f0423-2573-4616-94a7-98d3c8f4bf83", Activo = true, Correo = "consultor@azumat.cu", Roles = { new IdentityUserRole() { UserId = "3", RoleId = "3" } } },
                  new Usuario { Id = "4", UserName = "auditor", PasswordHash = "AIlw/bn9HUw29xFQ2o6Iyw8LNbWNQxS6N7wIJL4j3+RRD4v2Vc4too4U7uwSzsBXcQ==", SecurityStamp = "d31f0423-2573-4616-94a7-98d3c8f4bf84", Activo = true, Correo = "auditor@azumat.cu", Roles = { new IdentityUserRole() { UserId = "4", RoleId = "4" } } }
                );
            context.UnidadesOrganizativas.AddOrUpdate(
                 p => p.Id,
                 new UnidadOrganizativa { Id = 1, Nombre = "AZUMAT", Activa = true, Codigo = "1234" }
                );
            context.Areas.AddOrUpdate(
                  p => p.Id,
                  new Area { Id = 1, Nombre = " 1 Dirección", UnidadOrganizativaId = 1 },
                  new Area { Id = 2, Nombre = " 1,2 Cuadro", UnidadOrganizativaId = 1 },
                  new Area { Id = 3, Nombre = " 1,3 Jurídico", UnidadOrganizativaId = 1 },
                  new Area { Id = 4, Nombre = " 1,4 Seg-Prot", UnidadOrganizativaId = 1 },
                  new Area { Id = 5, Nombre = " 1,5 Inspección", UnidadOrganizativaId = 1 },
                  new Area { Id = 6, Nombre = " 1,6 ProdAgrop", UnidadOrganizativaId = 1 },
                  new Area { Id = 7, Nombre = " 2,1 Auditores", UnidadOrganizativaId = 1 },
                  new Area { Id = 8, Nombre = " 3,1 Contab y Fzas", UnidadOrganizativaId = 1 },
                  new Area { Id = 9, Nombre = " 3,2 Costo", UnidadOrganizativaId = 1 },
                  new Area { Id = 10, Nombre = " 3,3 Caja y Banco", UnidadOrganizativaId = 1 },
                  new Area { Id = 11, Nombre = " 3,4 Finanzas", UnidadOrganizativaId = 1 },
                  new Area { Id = 12, Nombre = " 3,5 NOMINA", UnidadOrganizativaId = 1 },
                  new Area { Id = 13, Nombre = " 3,6 Activos Fijos T", UnidadOrganizativaId = 1 },
                  new Area { Id = 14, Nombre = " 3,7 Plan yPresup", UnidadOrganizativaId = 1 },
                  new Area { Id = 15, Nombre = " 3,8 M Rotación N.", UnidadOrganizativaId = 1 },
                  new Area { Id = 16, Nombre = " 3,9 Faltant y Sob", UnidadOrganizativaId = 1 },
                  new Area { Id = 17, Nombre = " 4,1 Área Cap Hnos", UnidadOrganizativaId = 1 },
                  new Area { Id = 18, Nombre = " 5,1 Á.Comercial", UnidadOrganizativaId = 1 },
                  new Area { Id = 19, Nombre = " 5,2 Ciro Redondo", UnidadOrganizativaId = 1 },
                  new Area { Id = 20, Nombre = " 5,3 Recape", UnidadOrganizativaId = 1 },
                  new Area { Id = 21, Nombre = " 5,4 Amoniaco", UnidadOrganizativaId = 1 },
                  new Area { Id = 22, Nombre = " 5,5 DeposAcido", UnidadOrganizativaId = 1 },
                  new Area { Id = 23, Nombre = " 6,1 Combustible", UnidadOrganizativaId = 1 },
                  new Area { Id = 24, Nombre = " 6,2 SistEléctrico", UnidadOrganizativaId = 1 },
                  new Area { Id = 25, Nombre = " 6,3 Transportación", UnidadOrganizativaId = 1 },
                  new Area { Id = 26, Nombre = " 6,4 Área Puerto", UnidadOrganizativaId = 1 },
                  new Area { Id = 27, Nombre = " 7,1 SalaControl", UnidadOrganizativaId = 1 },
                  new Area { Id = 28, Nombre = " 7,2 Comunica Insti", UnidadOrganizativaId = 1 },
                  new Area { Id = 29, Nombre = " 7,3 Informática", UnidadOrganizativaId = 1 },
                  new Area { Id = 30, Nombre = " 8,1 Reservas Mat", UnidadOrganizativaId = 1 },
                  new Area { Id = 31, Nombre = " 8,2 Inversiones", UnidadOrganizativaId = 1 },
                  new Area { Id = 32, Nombre = " 8,3 Calidad", UnidadOrganizativaId = 1 },
                  new Area { Id = 33, Nombre = " 8,4 E Almacenes", UnidadOrganizativaId = 1 },
                  new Area { Id = 34, Nombre = " 8,5 C y Técnica", UnidadOrganizativaId = 1 }
                );

            context.Componentes.AddOrUpdate(
            p => p.Id,
                  new Componente { Id = 1, Nombre = "I- COMPONENTE AMBIENTE DE CONTROL", Descripcion = "Ambte Control", },
                  new Componente { Id = 2, Nombre = "II- COMPONENTE: GESTIÓN Y PREVENCIÓN DE RIESGOS ", Descripcion = "Gest. Prev. ", },
                  new Componente { Id = 3, Nombre = "III- COMPONENTE: ACTIVIDADES DE CONTROL ", Descripcion = "Act. Control ", },
                  new Componente { Id = 4, Nombre = "IV- COMPONENTE: INFORMACIÓN Y COMUNICACIÓN", Descripcion = "Inf. Comunic.", },
                  new Componente { Id = 5, Nombre = "V- COMPONENTE: SUPERVISIÓN Y MONITOREO", Descripcion = "Sup. Y Monit.", }
           );



            //context.Trabajadores.AddOrUpdate(
            //    t => t.Id,
            //    new Trabajador()
            //    {
            //        Id = 1,
            //        Ci = "85122345678",
            //        AreaId = 1,
            //        Activo = true,
            //        Nombres = "Pedro",
            //        PrimerApellido = "Perez",
            //        SegundoApellido = "Gonzalez",
            //        NoExpedienteLaboral = "465465DV",
            //        UsuarioId = "3"

            //    },
            //    new Trabajador()
            //    {
            //        Id = 2,
            //        Ci = "61122345695",
            //        AreaId = 2,
            //        Activo = true,
            //        Nombres = "Maria",
            //        PrimerApellido = "Perez",
            //        SegundoApellido = "Rodriguez",
            //        NoExpedienteLaboral = "4325436",
            //        UsuarioId = "4"
            //    },
            //    new Trabajador()
            //    {
            //        Id = 3,
            //        Ci = "60022612654",
            //        AreaId = 3,
            //        Activo = true,
            //        Nombres = "Ramon",
            //        PrimerApellido = "Ortiz",
            //        SegundoApellido = "Gonzalez",
            //        NoExpedienteLaboral = "234234"
            //    },
            //    new Trabajador()
            //    {
            //        Id = 4,
            //        Ci = "65061545923",
            //        AreaId = 4,
            //        Activo = true,
            //        Nombres = "Juan",
            //        PrimerApellido = "Hernandez",
            //        SegundoApellido = "Perez",
            //        NoExpedienteLaboral = "465465DV"
            //    },
            //    new Trabajador()
            //    {
            //        Id = 5,
            //        Ci = "70122243216",
            //        AreaId = 4,
            //        Activo = true,
            //        Nombres = "Jazmin",
            //        PrimerApellido = "De La Flor",
            //        SegundoApellido = "Gonzalez",
            //        NoExpedienteLaboral = "465465DV"
            //    },
            //    new Trabajador()
            //    {
            //        Id = 6,
            //        Ci = "85122345678",
            //        AreaId = 5,
            //        Activo = true,
            //        Nombres = "Raul",
            //        PrimerApellido = "Jimenez",
            //        SegundoApellido = "Hernandez",
            //        NoExpedienteLaboral = "465465DV"
            //    }
            //    );
        }
    }
}
