namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoRelacionTipoContenido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoRelacion", "TipoContenidoId", c => c.Int());
            CreateIndex("dbo.TipoRelacion", "TipoContenidoId");
            AddForeignKey("dbo.TipoRelacion", "TipoContenidoId", "dbo.TipoContenido", "TipoContenidoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoRelacion", "TipoContenidoId", "dbo.TipoContenido");
            DropIndex("dbo.TipoRelacion", new[] { "TipoContenidoId" });
            DropColumn("dbo.TipoRelacion", "TipoContenidoId");
        }
    }
}
