namespace AGCI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContenidoGuias", "Tipo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContenidoGuias", "Tipo");
        }
    }
}
