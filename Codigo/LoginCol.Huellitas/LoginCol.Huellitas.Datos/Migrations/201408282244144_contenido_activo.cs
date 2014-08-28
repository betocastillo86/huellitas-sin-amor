namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contenido_activo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contenido", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contenido", "Activo");
        }
    }
}
