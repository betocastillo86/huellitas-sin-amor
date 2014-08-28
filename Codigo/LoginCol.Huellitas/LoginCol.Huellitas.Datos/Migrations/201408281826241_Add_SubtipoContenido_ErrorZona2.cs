namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SubtipoContenido_ErrorZona2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ZonaGeografica", "ZonaGeograficaPadreId");
            RenameColumn(table: "dbo.ZonaGeografica", name: "ZonaGeograficaPadre_ZonaGeograficaId", newName: "ZonaGeograficaPadreId");
            RenameIndex(table: "dbo.ZonaGeografica", name: "IX_ZonaGeograficaPadre_ZonaGeograficaId", newName: "IX_ZonaGeograficaPadreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ZonaGeografica", name: "IX_ZonaGeograficaPadreId", newName: "IX_ZonaGeograficaPadre_ZonaGeograficaId");
            RenameColumn(table: "dbo.ZonaGeografica", name: "ZonaGeograficaPadreId", newName: "ZonaGeograficaPadre_ZonaGeograficaId");
            AddColumn("dbo.ZonaGeografica", "ZonaGeograficaPadreId", c => c.Int());
        }
    }
}
