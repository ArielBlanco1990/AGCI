namespace AGCI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migOk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AGCI_areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        UnidadOrganizativaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.rh_unidad_organizativa", t => t.UnidadOrganizativaId, cascadeDelete: true)
                .Index(t => t.UnidadOrganizativaId);
            
            CreateTable(
                "dbo.Componentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Area_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AGCI_areas", t => t.Area_Id)
                .Index(t => t.Area_Id);
            
            CreateTable(
                "dbo.ContenidoGuias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CGR = c.String(),
                        Otros = c.String(),
                        NoP = c.Int(),
                        NoPreguntas = c.Double(),
                        Numero = c.Int(),
                        Nombre = c.String(),
                        Si = c.Int(),
                        No = c.Int(),
                        Np = c.Int(),
                        Responsable = c.String(),
                        JefeInmediato = c.String(),
                        Direccion = c.String(),
                        ComponenteDescripcion = c.String(),
                        NormaName = c.String(),
                        GuiaId = c.Int(nullable: false),
                        Respuesta = c.Int(),
                        ComponenteId = c.Int(nullable: false),
                        NormaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Componentes", t => t.ComponenteId, cascadeDelete: true)
                .ForeignKey("dbo.Guias", t => t.GuiaId, cascadeDelete: true)
                .ForeignKey("dbo.Normas", t => t.NormaId)
                .Index(t => t.GuiaId)
                .Index(t => t.ComponenteId)
                .Index(t => t.NormaId);
            
            CreateTable(
                "dbo.Guias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaId = c.Int(nullable: false),
                        Año = c.Int(nullable: false),
                        Mes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AGCI_areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.PlanDeMedidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numerador = c.Int(nullable: false),
                        Numero = c.Double(),
                        DeficienciasSeñaladas = c.String(),
                        CausasCondiciones = c.String(),
                        Medidas = c.String(),
                        Ejecutor = c.String(),
                        Controla = c.String(),
                        FechaCumplimiento = c.DateTime(),
                        GuiaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guias", t => t.GuiaId, cascadeDelete: true)
                .Index(t => t.GuiaId);
            
            CreateTable(
                "dbo.Normas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ComponenteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Componentes", t => t.ComponenteId, cascadeDelete: true)
                .Index(t => t.ComponenteId);
            
            CreateTable(
                "dbo.GrupoPreguntas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        NormaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Normas", t => t.NormaId, cascadeDelete: true)
                .Index(t => t.NormaId);
            
            CreateTable(
                "dbo.Preguntas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        ComponenteDescripcion = c.String(),
                        NormaName = c.String(),
                        GrupoPreguntaId = c.Int(),
                        NormaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GrupoPreguntas", t => t.GrupoPreguntaId)
                .ForeignKey("dbo.Normas", t => t.NormaId)
                .Index(t => t.GrupoPreguntaId)
                .Index(t => t.NormaId);
            
            CreateTable(
                "dbo.TrabajadorAreas",
                c => new
                    {
                        TrabajadorId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrabajadorId, t.AreaId })
                .ForeignKey("dbo.AGCI_areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.rh_trabajadores", t => t.TrabajadorId, cascadeDelete: true)
                .Index(t => t.TrabajadorId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.rh_trabajadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ci = c.String(nullable: false, maxLength: 11),
                        Nombres = c.String(nullable: false),
                        PrimerApellido = c.String(nullable: false),
                        SegundoApellido = c.String(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        Activo = c.Boolean(nullable: false),
                        NoExpedienteLaboral = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Correo = c.String(),
                        Activo = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.rh_unidad_organizativa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Nombre = c.String(nullable: false),
                        Activa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AGCI_logs_de_accesos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                        Entrada = c.DateTime(),
                        Salida = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.AGCI_logs_de_cambios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TablaModificada = c.String(),
                        ValoresAnteriores = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ModeloGuias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CGR = c.String(),
                        Otros = c.String(),
                        NoP = c.Int(),
                        NoPreguntas = c.Double(),
                        Numero = c.Int(),
                        Nombre = c.String(),
                        Si = c.Int(),
                        No = c.Int(),
                        Np = c.Int(),
                        Responsable = c.String(),
                        JefeInmediato = c.String(),
                        Direccion = c.String(),
                        ComponenteDescripcion = c.String(),
                        Norma = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AGCI_logs_de_cambios", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AGCI_logs_de_accesos", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AGCI_areas", "UnidadOrganizativaId", "dbo.rh_unidad_organizativa");
            DropForeignKey("dbo.rh_trabajadores", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrabajadorAreas", "TrabajadorId", "dbo.rh_trabajadores");
            DropForeignKey("dbo.TrabajadorAreas", "AreaId", "dbo.AGCI_areas");
            DropForeignKey("dbo.Componentes", "Area_Id", "dbo.AGCI_areas");
            DropForeignKey("dbo.ContenidoGuias", "NormaId", "dbo.Normas");
            DropForeignKey("dbo.Preguntas", "NormaId", "dbo.Normas");
            DropForeignKey("dbo.Preguntas", "GrupoPreguntaId", "dbo.GrupoPreguntas");
            DropForeignKey("dbo.GrupoPreguntas", "NormaId", "dbo.Normas");
            DropForeignKey("dbo.Normas", "ComponenteId", "dbo.Componentes");
            DropForeignKey("dbo.PlanDeMedidas", "GuiaId", "dbo.Guias");
            DropForeignKey("dbo.ContenidoGuias", "GuiaId", "dbo.Guias");
            DropForeignKey("dbo.Guias", "AreaId", "dbo.AGCI_areas");
            DropForeignKey("dbo.ContenidoGuias", "ComponenteId", "dbo.Componentes");
            DropIndex("dbo.AGCI_logs_de_cambios", new[] { "UsuarioId" });
            DropIndex("dbo.AGCI_logs_de_accesos", new[] { "UsuarioId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.rh_trabajadores", new[] { "UsuarioId" });
            DropIndex("dbo.TrabajadorAreas", new[] { "AreaId" });
            DropIndex("dbo.TrabajadorAreas", new[] { "TrabajadorId" });
            DropIndex("dbo.Preguntas", new[] { "NormaId" });
            DropIndex("dbo.Preguntas", new[] { "GrupoPreguntaId" });
            DropIndex("dbo.GrupoPreguntas", new[] { "NormaId" });
            DropIndex("dbo.Normas", new[] { "ComponenteId" });
            DropIndex("dbo.PlanDeMedidas", new[] { "GuiaId" });
            DropIndex("dbo.Guias", new[] { "AreaId" });
            DropIndex("dbo.ContenidoGuias", new[] { "NormaId" });
            DropIndex("dbo.ContenidoGuias", new[] { "ComponenteId" });
            DropIndex("dbo.ContenidoGuias", new[] { "GuiaId" });
            DropIndex("dbo.Componentes", new[] { "Area_Id" });
            DropIndex("dbo.AGCI_areas", new[] { "UnidadOrganizativaId" });
            DropTable("dbo.ModeloGuias");
            DropTable("dbo.AGCI_logs_de_cambios");
            DropTable("dbo.AGCI_logs_de_accesos");
            DropTable("dbo.rh_unidad_organizativa");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.rh_trabajadores");
            DropTable("dbo.TrabajadorAreas");
            DropTable("dbo.Preguntas");
            DropTable("dbo.GrupoPreguntas");
            DropTable("dbo.Normas");
            DropTable("dbo.PlanDeMedidas");
            DropTable("dbo.Guias");
            DropTable("dbo.ContenidoGuias");
            DropTable("dbo.Componentes");
            DropTable("dbo.AGCI_areas");
        }
    }
}
