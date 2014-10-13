namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Configuraciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parametrizacion",
                c => new
                    {
                        Llave = c.String(nullable: false, maxLength: 20),
                        Valor = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Llave);
        }
        
        public override void Down()
        {
            DropTable("dbo.Parametrizacion");
        }
    }
}
