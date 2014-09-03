namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultaSqlEnCampoOpciones : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campo", "TipoContenidoId", "dbo.TipoContenido");
            DropIndex("dbo.Campo", new[] { "TipoContenidoId" });
            CreateTable(
                "dbo.OpcionCampo",
                c => new
                    {
                        OpcionId = c.Int(nullable: false, identity: true),
                        CampoId = c.Int(nullable: false),
                        Texto = c.String(),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OpcionId)
                .ForeignKey("dbo.Campo", t => t.CampoId, cascadeDelete: true)
                .Index(t => t.CampoId);
            
            CreateTable(
                "dbo.CampoTipoContenido",
                c => new
                    {
                        CampoTipoContenidoId = c.Int(nullable: false, identity: true),
                        CampoId = c.Int(nullable: false),
                        TipoContenidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CampoTipoContenidoId)
                .ForeignKey("dbo.Campo", t => t.CampoId)
                .ForeignKey("dbo.TipoContenido", t => t.TipoContenidoId)
                .Index(t => t.CampoId)
                .Index(t => t.TipoContenidoId);
            
            DropColumn("dbo.Campo", "TipoContenidoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campo", "TipoContenidoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CampoTipoContenido", "TipoContenidoId", "dbo.TipoContenido");
            DropForeignKey("dbo.CampoTipoContenido", "CampoId", "dbo.Campo");
            DropForeignKey("dbo.OpcionCampo", "CampoId", "dbo.Campo");
            DropIndex("dbo.CampoTipoContenido", new[] { "TipoContenidoId" });
            DropIndex("dbo.CampoTipoContenido", new[] { "CampoId" });
            DropIndex("dbo.OpcionCampo", new[] { "CampoId" });
            DropTable("dbo.CampoTipoContenido");
            DropTable("dbo.OpcionCampo");
            CreateIndex("dbo.Campo", "TipoContenidoId");
            AddForeignKey("dbo.Campo", "TipoContenidoId", "dbo.TipoContenido", "TipoContenidoId", cascadeDelete: true);
        }
    }
}
