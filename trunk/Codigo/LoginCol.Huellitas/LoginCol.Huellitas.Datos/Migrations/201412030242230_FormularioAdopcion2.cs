namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormularioAdopcion2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularioAdopcion", "FechaCreacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormularioAdopcion", "FechaCreacion");
        }
    }
}
