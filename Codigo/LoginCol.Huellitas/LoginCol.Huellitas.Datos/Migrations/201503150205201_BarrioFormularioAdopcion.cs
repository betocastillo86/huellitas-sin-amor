namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BarrioFormularioAdopcion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularioAdopcion", "Barrio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormularioAdopcion", "Barrio");
        }
    }
}
