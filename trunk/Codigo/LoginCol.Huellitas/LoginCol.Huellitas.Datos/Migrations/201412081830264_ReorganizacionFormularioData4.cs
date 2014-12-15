namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReorganizacionFormularioData4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularioAdopcion", "MiembrosFamilia", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "FechaNacimiento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "FechaNacimiento");
            DropColumn("dbo.FormularioAdopcion", "MiembrosFamilia");
        }
    }
}
