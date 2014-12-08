namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormularioAdopcion1 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Contenido", "UrlVideo", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta1", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta2", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta3", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta4", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta5", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta6", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta7", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta8", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta9", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta10", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta11", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta12", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta13", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta14", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta15", c => c.String());
            AddColumn("dbo.FormularioAdopcion", "RespuestaPregunta16", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta16");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta15");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta14");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta13");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta12");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta11");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta10");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta9");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta8");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta7");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta6");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta5");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta4");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta3");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta2");
            DropColumn("dbo.FormularioAdopcion", "RespuestaPregunta1");
            
        }
    }
}
