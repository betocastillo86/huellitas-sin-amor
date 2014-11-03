namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contenido", "UrlVideo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contenido", "UrlVideo");
        }
    }
}
