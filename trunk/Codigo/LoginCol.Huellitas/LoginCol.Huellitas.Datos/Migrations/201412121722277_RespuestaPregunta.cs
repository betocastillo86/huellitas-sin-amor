namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RespuestaPregunta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RespuestaAdopcion", "PreguntaId", "dbo.DatoTablaBasica");
            DropIndex("dbo.RespuestaAdopcion", new[] { "PreguntaId" });
            AddColumn("dbo.RespuestaAdopcion", "DatoTablaBasica_DatoTablaBasicaId", c => c.Int());
            CreateIndex("dbo.RespuestaAdopcion", "DatoTablaBasica_DatoTablaBasicaId");
            AddForeignKey("dbo.RespuestaAdopcion", "DatoTablaBasica_DatoTablaBasicaId", "dbo.DatoTablaBasica", "DatoTablaBasicaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RespuestaAdopcion", "DatoTablaBasica_DatoTablaBasicaId", "dbo.DatoTablaBasica");
            DropIndex("dbo.RespuestaAdopcion", new[] { "DatoTablaBasica_DatoTablaBasicaId" });
            DropColumn("dbo.RespuestaAdopcion", "DatoTablaBasica_DatoTablaBasicaId");
            CreateIndex("dbo.RespuestaAdopcion", "PreguntaId");
            AddForeignKey("dbo.RespuestaAdopcion", "PreguntaId", "dbo.DatoTablaBasica", "DatoTablaBasicaId");
        }
    }
}
