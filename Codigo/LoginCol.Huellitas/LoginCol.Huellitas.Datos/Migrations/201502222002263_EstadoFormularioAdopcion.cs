namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadoFormularioAdopcion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularioAdopcion", "Estado", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormularioAdopcion", "Estado");
        }
    }
}
