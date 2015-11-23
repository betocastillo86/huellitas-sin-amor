namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Paranetrizacion_Valor_4000 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parametrizacion", "Valor", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parametrizacion", "Valor", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
