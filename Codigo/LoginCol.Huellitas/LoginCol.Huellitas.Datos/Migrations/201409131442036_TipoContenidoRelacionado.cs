namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoContenidoRelacionado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoRelacionTipoContenido",
                c => new
                    {
                        TipoRelacionTipoContenidoId = c.Int(nullable: false, identity: true),
                        TipoContenidoId = c.Int(nullable: false),
                        TipoRelacionContenidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoRelacionTipoContenidoId)
                .ForeignKey("dbo.TipoContenido", t => t.TipoContenidoId, cascadeDelete: true)
                .ForeignKey("dbo.TipoRelacionContenido", t => t.TipoRelacionContenidoId, cascadeDelete: true)
                .Index(t => t.TipoContenidoId)
                .Index(t => t.TipoRelacionContenidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoRelacionTipoContenido", "TipoRelacionContenidoId", "dbo.TipoRelacionContenido");
            DropForeignKey("dbo.TipoRelacionTipoContenido", "TipoContenidoId", "dbo.TipoContenido");
            DropIndex("dbo.TipoRelacionTipoContenido", new[] { "TipoRelacionContenidoId" });
            DropIndex("dbo.TipoRelacionTipoContenido", new[] { "TipoContenidoId" });
            DropTable("dbo.TipoRelacionTipoContenido");
        }
    }
}
