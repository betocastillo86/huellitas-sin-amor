namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Configuraciones21 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Parametrizacion");
            AlterColumn("dbo.Parametrizacion", "Llave", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.Parametrizacion", "Llave");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Parametrizacion");
            AlterColumn("dbo.Parametrizacion", "Llave", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.Parametrizacion", "Llave");
        }
    }
}
