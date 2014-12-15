namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContenidoDestacado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contenido", "Destacado", c => c.Boolean(nullable: false, defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contenido", "Destacado");
        }
    }
}
