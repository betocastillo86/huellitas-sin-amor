namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescripcionCorta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contenido", "DescripcionCorta", c => c.String(nullable: false, maxLength: 130, defaultValue: "Ingresar descripción"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contenido", "DescripcionCorta");
        }
    }
}
