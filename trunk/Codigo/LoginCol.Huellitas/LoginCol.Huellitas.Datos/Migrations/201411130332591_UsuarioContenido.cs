namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioContenido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioContenido",
                c => new
                    {
                        UsuarioContenidoId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        ContenidoId = c.Int(nullable: false),
                        TipoRelacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioContenidoId)
                .ForeignKey("dbo.Contenido", t => t.ContenidoId)
                .ForeignKey("dbo.TipoRelacion", t => t.TipoRelacionId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ContenidoId)
                .Index(t => t.TipoRelacionId);
            
            CreateTable(
                "dbo.TipoRelacion",
                c => new
                    {
                        TipoRelacionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 20),
                        Descripcion = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.TipoRelacionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioContenido", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.UsuarioContenido", "TipoRelacionId", "dbo.TipoRelacion");
            DropForeignKey("dbo.UsuarioContenido", "ContenidoId", "dbo.Contenido");
            DropIndex("dbo.UsuarioContenido", new[] { "TipoRelacionId" });
            DropIndex("dbo.UsuarioContenido", new[] { "ContenidoId" });
            DropIndex("dbo.UsuarioContenido", new[] { "UsuarioId" });
            DropTable("dbo.TipoRelacion");
            DropTable("dbo.UsuarioContenido");
        }
    }
}
