namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Configuraciones2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parametrizacion", "Valor", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parametrizacion", "Valor", c => c.String(maxLength: 500));
        }
    }
}
