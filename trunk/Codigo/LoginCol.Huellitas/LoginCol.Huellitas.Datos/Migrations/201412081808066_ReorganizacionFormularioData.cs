namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReorganizacionFormularioData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RespuestaAdopcion",
                c => new
                    {
                        RespuestaAdopcionId = c.Int(nullable: false, identity: true),
                        FormularioAdopcionId = c.Int(nullable: false),
                        PreguntaId = c.Int(nullable: false),
                        Respuesta = c.String(),
                        Pregunta_TablaBasicaId = c.Int(),
                    })
                .PrimaryKey(t => t.RespuestaAdopcionId)
                .ForeignKey("dbo.FormularioAdopcion", t => t.FormularioAdopcionId, cascadeDelete: true)
                .ForeignKey("dbo.TablaBasica", t => t.Pregunta_TablaBasicaId)
                .Index(t => t.FormularioAdopcionId)
                .Index(t => t.Pregunta_TablaBasicaId);
            
            AddColumn("dbo.FormularioAdopcion", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId", c => c.Int());
            AddColumn("dbo.Usuario", "Direccion", c => c.String());
            AddColumn("dbo.Usuario", "Telefono", c => c.String());
            AddColumn("dbo.Usuario", "Celular", c => c.String());
            AddColumn("dbo.Usuario", "OcupacionId", c => c.Int());
            AddColumn("dbo.Usuario", "EstadoCivilId", c => c.Int());
            AddColumn("dbo.Usuario", "EstadoCivil_TablaBasicaId", c => c.Int());
            AddColumn("dbo.Usuario", "Ocupacion_TablaBasicaId", c => c.Int());
            CreateIndex("dbo.FormularioAdopcion", "UsuarioId");
            CreateIndex("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId");
            CreateIndex("dbo.Usuario", "EstadoCivil_TablaBasicaId");
            CreateIndex("dbo.Usuario", "Ocupacion_TablaBasicaId");
            AddForeignKey("dbo.Usuario", "EstadoCivil_TablaBasicaId", "dbo.TablaBasica", "TablaBasicaId");
            AddForeignKey("dbo.FormularioAdopcion", "UsuarioId", "dbo.Usuario", "UsuarioId");
            AddForeignKey("dbo.Usuario", "Ocupacion_TablaBasicaId", "dbo.TablaBasica", "TablaBasicaId");
            AddForeignKey("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId", "dbo.ZonaGeografica", "ZonaGeograficaId");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta1");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta2");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta3");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta4");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta5");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta6");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta7");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta8");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta9");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta10");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta11");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta12");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta13");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta14");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta15");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta16");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta16", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta15", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta14", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta13", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta12", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta11", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta10", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta9", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta8", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta7", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta6", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta5", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta4", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta3", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta2", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta1", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "MiembrosFamilia", c => c.Int(nullable: false));
            AddColumn("dbo.FormularioAdopcion", "EstadoCivil", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "CorreoElectronico", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "Celular", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "Telefono", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "Direccion", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "Ciudad", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "Ocupacion", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "Edad", c => c.Int(nullable: false));
            AddColumn("dbo.FormularioAdopcion", "Nombre", c => c.String());
            DropForeignKey("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId", "dbo.ZonaGeografica");
            DropForeignKey("dbo.Usuario", "Ocupacion_TablaBasicaId", "dbo.TablaBasica");
            DropForeignKey("dbo.FormularioAdopcion", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "EstadoCivil_TablaBasicaId", "dbo.TablaBasica");
            DropForeignKey("dbo.RespuestaAdopcion", "Pregunta_TablaBasicaId", "dbo.TablaBasica");
            DropForeignKey("dbo.RespuestaAdopcion", "FormularioAdopcionId", "dbo.FormularioAdopcion");
            DropIndex("dbo.Usuario", new[] { "Ocupacion_TablaBasicaId" });
            DropIndex("dbo.Usuario", new[] { "EstadoCivil_TablaBasicaId" });
            DropIndex("dbo.RespuestaAdopcion", new[] { "Pregunta_TablaBasicaId" });
            DropIndex("dbo.RespuestaAdopcion", new[] { "FormularioAdopcionId" });
            DropIndex("dbo.FormularioAdopcion", new[] { "ZonaGeografica_ZonaGeograficaId" });
            DropIndex("dbo.FormularioAdopcion", new[] { "UsuarioId" });
            DropColumn("dbo.Usuario", "Ocupacion_TablaBasicaId");
            DropColumn("dbo.Usuario", "EstadoCivil_TablaBasicaId");
            DropColumn("dbo.Usuario", "EstadoCivilId");
            DropColumn("dbo.Usuario", "OcupacionId");
            DropColumn("dbo.Usuario", "Celular");
            DropColumn("dbo.Usuario", "Telefono");
            DropColumn("dbo.Usuario", "Direccion");
            DropColumn("dbo.FormularioAdopcion", "ZonaGeografica_ZonaGeograficaId");
            DropColumn("dbo.FormularioAdopcion", "UsuarioId");
            DropTable("dbo.RespuestaAdopcion");
        }
    }
}
