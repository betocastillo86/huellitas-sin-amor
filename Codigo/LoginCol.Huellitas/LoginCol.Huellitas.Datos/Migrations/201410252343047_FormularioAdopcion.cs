namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormularioAdopcion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormularioAdopcion",
                c => new
                    {
                        FormularioAdopcionId = c.Int(nullable: false, identity: true),
                        ContenidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FormularioAdopcionId)
                .ForeignKey("dbo.Contenido", t => t.ContenidoId, cascadeDelete: true)
                .Index(t => t.ContenidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormularioAdopcion", "ContenidoId", "dbo.Contenido");
            DropIndex("dbo.FormularioAdopcion", new[] { "ContenidoId" });
            DropTable("dbo.FormularioAdopcion");
        }
    }
}
