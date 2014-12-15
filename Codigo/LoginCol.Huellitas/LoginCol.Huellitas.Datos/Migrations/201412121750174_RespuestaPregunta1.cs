namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RespuestaPregunta1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RespuestaAdopcion", new[] { "DatoTablaBasica_DatoTablaBasicaId" });
            DropForeignKey("dbo.RespuestaAdopcion", "FK_dbo.RespuestaAdopcion_dbo.DatoTablaBasica_DatoTablaBasica_DatoTablaBasicaId");
            DropColumn("dbo.RespuestaAdopcion", "DatoTablaBasica_DatoTablaBasicaId");
            //RenameColumn(table: "dbo.RespuestaAdopcion", name: "DatoTablaBasica_DatoTablaBasicaId", newName: "PreguntaId");
            //AlterColumn("dbo.RespuestaAdopcion", "PreguntaId", c => c.Int(nullable: false));
            //CreateIndex("dbo.RespuestaAdopcion", "PreguntaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RespuestaAdopcion", new[] { "PreguntaId" });
            AlterColumn("dbo.RespuestaAdopcion", "PreguntaId", c => c.Int());
            RenameColumn(table: "dbo.RespuestaAdopcion", name: "PreguntaId", newName: "DatoTablaBasica_DatoTablaBasicaId");
            AddColumn("dbo.RespuestaAdopcion", "PreguntaId", c => c.Int(nullable: false));
            CreateIndex("dbo.RespuestaAdopcion", "DatoTablaBasica_DatoTablaBasicaId");
        }
    }
}
