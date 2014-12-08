namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreguntasFormulario1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PreguntasFormulario", "ContenidoId", "dbo.Contenido");
            DropIndex("dbo.PreguntasFormulario", new[] { "ContenidoId" });
            DropTable("dbo.PreguntasFormulario");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PreguntasFormulario",
                c => new
                    {
                        PreguntasFormularioId = c.Int(nullable: false, identity: true),
                        ContenidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PreguntasFormularioId);
            
            CreateIndex("dbo.PreguntasFormulario", "ContenidoId");
            AddForeignKey("dbo.PreguntasFormulario", "ContenidoId", "dbo.Contenido", "ContenidoId", cascadeDelete: true);
        }
    }
}
