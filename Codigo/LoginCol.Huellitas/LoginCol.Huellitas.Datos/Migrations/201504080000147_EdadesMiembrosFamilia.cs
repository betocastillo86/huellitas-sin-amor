namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EdadesMiembrosFamilia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularioAdopcion", "EdadesMiembrosFamilia", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormularioAdopcion", "EdadesMiembrosFamilia");
        }
    }
}
