namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuitarContacto_Contenido : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contenido", "Direccion");
            DropColumn("dbo.Contenido", "Telefono");
            DropColumn("dbo.Contenido", "Latitud");
            DropColumn("dbo.Contenido", "Longitud");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contenido", "Longitud", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contenido", "Latitud", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contenido", "Telefono", c => c.String());
            AddColumn("dbo.Contenido", "Direccion", c => c.String());
        }
    }
}
