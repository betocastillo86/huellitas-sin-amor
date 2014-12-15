namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RespuestaPregunta2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RespuestaAdopcion", "PreguntaId", c => c.Int(nullable: false));
            CreateIndex("dbo.RespuestaAdopcion", "PreguntaId");
            AddForeignKey("dbo.RespuestaAdopcion", "PreguntaId", "dbo.DatoTablaBasica", "DatoTablaBasicaId");

        }
        
        public override void Down()
        {
            DropIndex("dbo.RespuestaAdopcion", new[] { "DatoTablaBasica_DatoTablaBasicaId" });
            AlterColumn("dbo.RespuestaAdopcion", "DatoTablaBasica_DatoTablaBasicaId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RespuestaAdopcion", name: "DatoTablaBasica_DatoTablaBasicaId", newName: "PreguntaId");
            CreateIndex("dbo.RespuestaAdopcion", "PreguntaId");
        }
    }
}
