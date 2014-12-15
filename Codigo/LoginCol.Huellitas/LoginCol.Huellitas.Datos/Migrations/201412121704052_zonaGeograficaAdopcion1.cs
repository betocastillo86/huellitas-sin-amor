namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zonaGeograficaAdopcion1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FormularioAdopcion", "EdadesMiembros");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormularioAdopcion", "EdadesMiembros", c => c.String());
        }
    }
}
