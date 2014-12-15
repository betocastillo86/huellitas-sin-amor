namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadoCivil : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.EstadoCivil", "ContenidoId", "dbo.Contenido");
            //DropIndex("dbo.EstadoCivil", new[] { "ContenidoId" });
            //DropTable("dbo.EstadoCivil");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.EstadoCivil",
            //    c => new
            //        {
            //            EstadoCivilId = c.Int(nullable: false, identity: true),
            //            ContenidoId = c.Int(nullable: false),
            //            Descripcion = c.String(),
            //        })
            //    .PrimaryKey(t => t.EstadoCivilId);
            
            //CreateIndex("dbo.EstadoCivil", "ContenidoId");
            //AddForeignKey("dbo.EstadoCivil", "ContenidoId", "dbo.Contenido", "ContenidoId", cascadeDelete: true);
        }
    }
}
