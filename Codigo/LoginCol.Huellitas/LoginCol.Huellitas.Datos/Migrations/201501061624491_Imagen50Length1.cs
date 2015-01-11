namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imagen50Length1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contenido", "Imagen", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contenido", "Imagen", c => c.String(maxLength: 20));
        }
    }
}
