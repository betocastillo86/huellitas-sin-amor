namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReorganizacionFormularioData2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RespuestaAdopcion", new[] { "Pregunta_TablaBasicaId" });
            DropColumn("dbo.RespuestaAdopcion", "PreguntaId");
            RenameColumn(table: "dbo.RespuestaAdopcion", name: "Pregunta_TablaBasicaId", newName: "PreguntaId");
            AlterColumn("dbo.RespuestaAdopcion", "PreguntaId", c => c.Int(nullable: false));
            CreateIndex("dbo.RespuestaAdopcion", "PreguntaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RespuestaAdopcion", new[] { "PreguntaId" });
            AlterColumn("dbo.RespuestaAdopcion", "PreguntaId", c => c.Int());
            RenameColumn(table: "dbo.RespuestaAdopcion", name: "PreguntaId", newName: "Pregunta_TablaBasicaId");
            AddColumn("dbo.RespuestaAdopcion", "PreguntaId", c => c.Int(nullable: false));
            CreateIndex("dbo.RespuestaAdopcion", "Pregunta_TablaBasicaId");
        }
    }
}
