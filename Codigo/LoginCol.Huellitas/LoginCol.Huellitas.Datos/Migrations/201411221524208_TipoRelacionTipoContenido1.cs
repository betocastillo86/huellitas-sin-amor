namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoRelacionTipoContenido1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TipoRelacion", new[] { "TipoContenidoId" });
            AlterColumn("dbo.TipoRelacion", "TipoContenidoId", c => c.Int(nullable: false));
            CreateIndex("dbo.TipoRelacion", "TipoContenidoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TipoRelacion", new[] { "TipoContenidoId" });
            AlterColumn("dbo.TipoRelacion", "TipoContenidoId", c => c.Int());
            CreateIndex("dbo.TipoRelacion", "TipoContenidoId");
        }
    }
}
