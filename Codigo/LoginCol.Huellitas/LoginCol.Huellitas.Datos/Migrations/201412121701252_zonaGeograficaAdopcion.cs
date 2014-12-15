namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zonaGeograficaAdopcion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId", "dbo.ZonaGeografica");
            DropIndex("dbo.FormularioAdopcion", new[] { "ZonaGeografica_ZonaGeograficaId" });
            DropColumn("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId", c => c.Int());
            CreateIndex("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId");
            AddForeignKey("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId", "dbo.ZonaGeografica", "ZonaGeograficaId");
        }
    }
}
