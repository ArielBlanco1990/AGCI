namespace AGCI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migLeyFecha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContenidoGuias", "FechaDeVencimiento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContenidoGuias", "FechaDeVencimiento");
        }
    }
}
