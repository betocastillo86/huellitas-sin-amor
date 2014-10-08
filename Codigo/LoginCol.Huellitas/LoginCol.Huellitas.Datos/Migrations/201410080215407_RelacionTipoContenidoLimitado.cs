namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionTipoContenidoLimitado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoRelacionContenido", "TipoContenidoId", c => c.Int(nullable: false));
            AddColumn("dbo.TipoRelacionContenido", "MaximoRegistros", c => c.Int(nullable: false));
            CreateIndex("dbo.TipoRelacionContenido", "TipoContenidoId");
            AddForeignKey("dbo.TipoRelacionContenido", "TipoContenidoId", "dbo.TipoContenido", "TipoContenidoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoRelacionContenido", "TipoContenidoId", "dbo.TipoContenido");
            DropIndex("dbo.TipoRelacionContenido", new[] { "TipoContenidoId" });
            DropColumn("dbo.TipoRelacionContenido", "MaximoRegistros");
            DropColumn("dbo.TipoRelacionContenido", "TipoContenidoId");
        }
    }
}
