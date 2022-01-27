namespace AGCI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migLey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaVencimiento = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContenidoGuias", "LeyId", c => c.Int());
            AddColumn("dbo.Preguntas", "LeyId", c => c.Int());
            CreateIndex("dbo.ContenidoGuias", "LeyId");
            CreateIndex("dbo.Preguntas", "LeyId");
            AddForeignKey("dbo.Preguntas", "LeyId", "dbo.Leys", "Id");
            AddForeignKey("dbo.ContenidoGuias", "LeyId", "dbo.Leys", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContenidoGuias", "LeyId", "dbo.Leys");
            DropForeignKey("dbo.Preguntas", "LeyId", "dbo.Leys");
            DropIndex("dbo.Preguntas", new[] { "LeyId" });
            DropIndex("dbo.ContenidoGuias", new[] { "LeyId" });
            DropColumn("dbo.Preguntas", "LeyId");
            DropColumn("dbo.ContenidoGuias", "LeyId");
            DropTable("dbo.Leys");
        }
    }
}
