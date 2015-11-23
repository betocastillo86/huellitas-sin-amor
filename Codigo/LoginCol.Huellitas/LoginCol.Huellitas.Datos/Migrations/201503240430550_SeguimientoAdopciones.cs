namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeguimientoAdopciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adopcion",
                c => new
                    {
                        AdopcionId = c.Int(nullable: false),
                        AdoptanteId = c.Int(nullable: false),
                        FormularioId = c.Int(nullable: false),
                        FechaAdopcion = c.DateTime(nullable: false),
                        ContenidoId = c.Int(nullable: false),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.AdopcionId)
                .ForeignKey("dbo.Usuario", t => t.AdoptanteId)
                .ForeignKey("dbo.Contenido", t => t.ContenidoId, cascadeDelete: true)
                .ForeignKey("dbo.FormularioAdopcion", t => t.AdopcionId)
                .Index(t => t.AdopcionId)
                .Index(t => t.AdoptanteId)
                .Index(t => t.ContenidoId);
            
            CreateTable(
                "dbo.RespuestaSeguimiento",
                c => new
                    {
                        RespuestaSeguimientoId = c.Int(nullable: false, identity: true),
                        SeguimientoId = c.Int(nullable: false),
                        PreguntaId = c.Int(nullable: false),
                        Respuesta = c.String(),
                    })
                .PrimaryKey(t => t.RespuestaSeguimientoId)
                .ForeignKey("dbo.SeguimientoAdopcion", t => t.SeguimientoId)
                .ForeignKey("dbo.DatoTablaBasica", t => t.PreguntaId)
                .Index(t => t.SeguimientoId)
                .Index(t => t.PreguntaId);
            
            CreateTable(
                "dbo.SeguimientoAdopcion",
                c => new
                    {
                        SeguimientoAdopcionId = c.Int(nullable: false, identity: true),
                        AdopcionId = c.Int(nullable: false),
                        Imagen1 = c.Boolean(nullable:false),
                        Imagen2 = c.Boolean(nullable: false),
                        Video = c.String(maxLength: 50),
                        FechaRespuesta = c.DateTime(nullable: false),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.SeguimientoAdopcionId)
                .ForeignKey("dbo.Adopcion", t => t.AdopcionId)
                .Index(t => t.AdopcionId);
            
            AddColumn("dbo.FormularioAdopcion", "AdopcionId", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeguimientoAdopcion", "AdopcionId", "dbo.Adopcion");
            DropForeignKey("dbo.Adopcion", "AdopcionId", "dbo.FormularioAdopcion");
            DropForeignKey("dbo.Adopcion", "ContenidoId", "dbo.Contenido");
            DropForeignKey("dbo.RespuestaSeguimiento", "PreguntaId", "dbo.DatoTablaBasica");
            DropForeignKey("dbo.RespuestaSeguimiento", "SeguimientoId", "dbo.SeguimientoAdopcion");
            DropForeignKey("dbo.Adopcion", "AdoptanteId", "dbo.Usuario");
            DropIndex("dbo.SeguimientoAdopcion", new[] { "AdopcionId" });
            DropIndex("dbo.RespuestaSeguimiento", new[] { "PreguntaId" });
            DropIndex("dbo.RespuestaSeguimiento", new[] { "SeguimientoId" });
            DropIndex("dbo.Adopcion", new[] { "ContenidoId" });
            DropIndex("dbo.Adopcion", new[] { "AdoptanteId" });
            DropIndex("dbo.Adopcion", new[] { "AdopcionId" });
            DropColumn("dbo.FormularioAdopcion", "AdopcionId");
            DropTable("dbo.SeguimientoAdopcion");
            DropTable("dbo.RespuestaSeguimiento");
            DropTable("dbo.Adopcion");
        }
    }
}
