namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposActivos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campo", "Activo", c => c.Boolean(nullable: false, defaultValue : true));
            AddColumn("dbo.OpcionCampo", "Activo", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.TipoRelacion", "Activo", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.ZonaGeografica", "Activo", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ZonaGeografica", "Activo");
            DropColumn("dbo.TipoRelacion", "Activo");
            DropColumn("dbo.OpcionCampo", "Activo");
            DropColumn("dbo.Campo", "Activo");
        }
    }
}
