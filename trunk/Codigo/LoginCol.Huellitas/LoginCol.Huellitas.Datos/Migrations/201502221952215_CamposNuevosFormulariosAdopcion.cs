namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposNuevosFormulariosAdopcion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularioAdopcion", "InformacionAdicionalCorreo", c => c.String(maxLength: 3000));
            AddColumn("dbo.FormularioAdopcion", "Observaciones", c => c.String(maxLength: 3000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormularioAdopcion", "Observaciones");
            DropColumn("dbo.FormularioAdopcion", "InformacionAdicionalCorreo");
        }
    }
}
