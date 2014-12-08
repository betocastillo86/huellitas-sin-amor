namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatoTablaBasica : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatoTablaBasica",
                c => new
                    {
                        DatoTablaBasicaId = c.Int(nullable: false, identity: true),
                        TablaBasicaId = c.Int(nullable: false),
                        Valor = c.String(),
                        ValorIngles = c.String(),
                        PadreId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        CodigoExterno = c.String(),
                        InformacionAdicional = c.String(),
                    })
                .PrimaryKey(t => t.DatoTablaBasicaId)
                .ForeignKey("dbo.TablaBasica", t => t.TablaBasicaId, cascadeDelete: true)
                .Index(t => t.TablaBasicaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatoTablaBasica", "TablaBasicaId", "dbo.TablaBasica");
            DropIndex("dbo.DatoTablaBasica", new[] { "TablaBasicaId" });
            DropTable("dbo.DatoTablaBasica");
        }
    }
}
