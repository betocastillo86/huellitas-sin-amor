namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreguntasFormulario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PreguntasFormulario",
                c => new
                    {
                        PreguntasFormularioId = c.Int(nullable: false, identity: true),
                        ContenidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PreguntasFormularioId)
                .ForeignKey("dbo.Contenido", t => t.ContenidoId, cascadeDelete: true)
                .Index(t => t.ContenidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PreguntasFormulario", "ContenidoId", "dbo.Contenido");
            DropIndex("dbo.PreguntasFormulario", new[] { "ContenidoId" });
            DropTable("dbo.PreguntasFormulario");
        }
    }
}
