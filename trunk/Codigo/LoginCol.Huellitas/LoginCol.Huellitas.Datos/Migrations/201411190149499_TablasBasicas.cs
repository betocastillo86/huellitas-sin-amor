namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasBasicas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TablaBasica",
                c => new
                    {
                        TablaBasicaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TablaBasicaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TablaBasica");
        }
    }
}
