namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraVersion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campo",
                c => new
                    {
                        CampoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        TipoDato = c.Int(nullable: false),
                        TipoContenidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CampoId)
                .ForeignKey("dbo.TipoContenido", t => t.TipoContenidoId, cascadeDelete: true)
                .Index(t => t.TipoContenidoId);
            
            CreateTable(
                "dbo.TipoContenido",
                c => new
                    {
                        TipoContenidoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TipoContenidoId);
            
            CreateTable(
                "dbo.Contenido",
                c => new
                    {
                        ContenidoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(),
                        Visitas = c.Int(nullable: false),
                        Comentarios = c.Int(nullable: false),
                        Votos = c.Int(nullable: false),
                        PromedioVotos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaActualizacion = c.DateTime(),
                        FechaPublicacion = c.DateTime(),
                        TipoContenidoId = c.Int(nullable: false),
                        MeGusta = c.Int(nullable: false),
                        Compartidos = c.Int(nullable: false),
                        Imagen = c.String(maxLength: 20),
                        ZonaGeograficaId = c.Int(nullable: false),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Latitud = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitud = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContenidoId)
                .ForeignKey("dbo.TipoContenido", t => t.TipoContenidoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.ZonaGeografica", t => t.ZonaGeograficaId, cascadeDelete: true)
                .Index(t => t.TipoContenidoId)
                .Index(t => t.ZonaGeograficaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ValorCampo",
                c => new
                    {
                        ValorCampoId = c.Int(nullable: false, identity: true),
                        CampoId = c.Int(nullable: false),
                        ContenidoId = c.Int(nullable: false),
                        Valor = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ValorCampoId)
                .ForeignKey("dbo.Campo", t => t.CampoId)
                .ForeignKey("dbo.Contenido", t => t.ContenidoId)
                .Index(t => t.CampoId)
                .Index(t => t.ContenidoId);
            
            CreateTable(
                "dbo.ContenidoRelacionado",
                c => new
                    {
                        ContenidoRelacionadoId = c.Int(nullable: false, identity: true),
                        ContenidoId = c.Int(nullable: false),
                        ContenidoPadreId = c.Int(nullable: false),
                        TipoRelacionContenidoId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContenidoRelacionadoId)
                .ForeignKey("dbo.Contenido", t => t.ContenidoId)
                .ForeignKey("dbo.Contenido", t => t.ContenidoPadreId)
                .ForeignKey("dbo.TipoRelacionContenido", t => t.TipoRelacionContenidoId)
                .Index(t => t.ContenidoId)
                .Index(t => t.ContenidoPadreId)
                .Index(t => t.TipoRelacionContenidoId);
            
            CreateTable(
                "dbo.TipoRelacionContenido",
                c => new
                    {
                        TipoRelacionContenidoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoRelacionContenidoId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Correo = c.String(nullable: false, maxLength: 50),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false),
                        Clave = c.String(nullable: false, maxLength: 50),
                        NumeroDocumento = c.String(maxLength: 15),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaActualizacion = c.DateTime(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        ComentarioId = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        ContenidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComentarioId)
                .ForeignKey("dbo.Contenido", t => t.ContenidoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ContenidoId);
            
            CreateTable(
                "dbo.ZonaGeografica",
                c => new
                    {
                        ZonaGeograficaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        CodigoExterno = c.String(),
                        ZonaGeograficaPadreId = c.Int(),
                        ZonaGeograficaPadre_ZonaGeograficaId = c.Int(),
                    })
                .PrimaryKey(t => t.ZonaGeograficaId)
                .ForeignKey("dbo.ZonaGeografica", t => t.ZonaGeograficaPadre_ZonaGeograficaId)
                .Index(t => t.ZonaGeograficaPadre_ZonaGeograficaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contenido", "ZonaGeograficaId", "dbo.ZonaGeografica");
            DropForeignKey("dbo.ZonaGeografica", "ZonaGeograficaPadre_ZonaGeograficaId", "dbo.ZonaGeografica");
            DropForeignKey("dbo.Contenido", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Comentario", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Comentario", "ContenidoId", "dbo.Contenido");
            DropForeignKey("dbo.Contenido", "TipoContenidoId", "dbo.TipoContenido");
            DropForeignKey("dbo.ContenidoRelacionado", "TipoRelacionContenidoId", "dbo.TipoRelacionContenido");
            DropForeignKey("dbo.ContenidoRelacionado", "ContenidoPadreId", "dbo.Contenido");
            DropForeignKey("dbo.ContenidoRelacionado", "ContenidoId", "dbo.Contenido");
            DropForeignKey("dbo.ValorCampo", "ContenidoId", "dbo.Contenido");
            DropForeignKey("dbo.ValorCampo", "CampoId", "dbo.Campo");
            DropForeignKey("dbo.Campo", "TipoContenidoId", "dbo.TipoContenido");
            DropIndex("dbo.ZonaGeografica", new[] { "ZonaGeograficaPadre_ZonaGeograficaId" });
            DropIndex("dbo.Comentario", new[] { "ContenidoId" });
            DropIndex("dbo.Comentario", new[] { "UsuarioId" });
            DropIndex("dbo.ContenidoRelacionado", new[] { "TipoRelacionContenidoId" });
            DropIndex("dbo.ContenidoRelacionado", new[] { "ContenidoPadreId" });
            DropIndex("dbo.ContenidoRelacionado", new[] { "ContenidoId" });
            DropIndex("dbo.ValorCampo", new[] { "ContenidoId" });
            DropIndex("dbo.ValorCampo", new[] { "CampoId" });
            DropIndex("dbo.Contenido", new[] { "UsuarioId" });
            DropIndex("dbo.Contenido", new[] { "ZonaGeograficaId" });
            DropIndex("dbo.Contenido", new[] { "TipoContenidoId" });
            DropIndex("dbo.Campo", new[] { "TipoContenidoId" });
            DropTable("dbo.ZonaGeografica");
            DropTable("dbo.Comentario");
            DropTable("dbo.Usuario");
            DropTable("dbo.TipoRelacionContenido");
            DropTable("dbo.ContenidoRelacionado");
            DropTable("dbo.ValorCampo");
            DropTable("dbo.Contenido");
            DropTable("dbo.TipoContenido");
            DropTable("dbo.Campo");
        }
    }
}
