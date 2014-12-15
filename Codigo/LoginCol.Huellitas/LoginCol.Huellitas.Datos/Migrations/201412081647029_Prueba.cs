namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prueba : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.FormularioAdopcion",
            //    c => new
            //        {
            //            FormularioAdopcionId = c.Int(nullable: false, identity: true),
            //            ContenidoId = c.Int(nullable: false),
            //            Nombre = c.String(),
            //            Edad = c.Int(nullable: false),
            //            Ocupacion = c.String(),
            //            Ciudad = c.String(),
            //            Direccion = c.String(),
            //            Telefono = c.String(),
            //            Celular = c.String(),
            //            CorreoElectronico = c.String(),
            //            EstadoCivil = c.String(),
            //            MiembrosFamilia = c.Int(nullable: false),
            //            EdadesMiembros = c.String(),
            //            RespuestaPregunta1 = c.String(),
            //            RespuestaPregunta2 = c.String(),
            //            RespuestaPregunta3 = c.String(),
            //            RespuestaPregunta4 = c.String(),
            //            RespuestaPregunta5 = c.String(),
            //            RespuestaPregunta6 = c.String(),
            //            RespuestaPregunta7 = c.String(),
            //            RespuestaPregunta8 = c.String(),
            //            RespuestaPregunta9 = c.String(),
            //            RespuestaPregunta10 = c.String(),
            //            RespuestaPregunta11 = c.String(),
            //            RespuestaPregunta12 = c.String(),
            //            RespuestaPregunta13 = c.String(),
            //            RespuestaPregunta14 = c.String(),
            //            RespuestaPregunta15 = c.String(),
            //            RespuestaPregunta16 = c.String(),
            //            FechaCreacion = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.FormularioAdopcionId)
            //    .ForeignKey("dbo.Contenido", t => t.ContenidoId, cascadeDelete: true)
            //    .Index(t => t.ContenidoId);
            
            //CreateTable(
            //    "dbo.DatoTablaBasica",
            //    c => new
            //        {
            //            DatoTablaBasicaId = c.Int(nullable: false, identity: true),
            //            TablaBasicaId = c.Int(nullable: false),
            //            Valor = c.String(),
            //            ValorIngles = c.String(),
            //            PadreId = c.Int(nullable: false),
            //            Activo = c.Boolean(nullable: false),
            //            CodigoExterno = c.String(),
            //            InformacionAdicional = c.String(),
            //        })
            //    .PrimaryKey(t => t.DatoTablaBasicaId)
            //    .ForeignKey("dbo.TablaBasica", t => t.TablaBasicaId, cascadeDelete: true)
            //    .Index(t => t.TablaBasicaId);
            
            //CreateTable(
            //    "dbo.TablaBasica",
            //    c => new
            //        {
            //            TablaBasicaId = c.Int(nullable: false, identity: true),
            //            Nombre = c.String(),
            //            Descripcion = c.String(),
            //        })
            //    .PrimaryKey(t => t.TablaBasicaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatoTablaBasica", "TablaBasicaId", "dbo.TablaBasica");
            DropForeignKey("dbo.FormularioAdopcion", "ContenidoId", "dbo.Contenido");
            DropIndex("dbo.DatoTablaBasica", new[] { "TablaBasicaId" });
            DropIndex("dbo.FormularioAdopcion", new[] { "ContenidoId" });
            DropTable("dbo.TablaBasica");
            DropTable("dbo.DatoTablaBasica");
            DropTable("dbo.FormularioAdopcion");
        }
    }
}
