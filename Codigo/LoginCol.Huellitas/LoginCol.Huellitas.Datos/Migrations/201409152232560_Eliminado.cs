namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eliminado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contenido", "Eliminado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contenido", "Eliminado");
        }
    }
}
