namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposObligatorios_Adpocion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adopcion", "FechaCreacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Adopcion", "Observaciones", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adopcion", "Observaciones", c => c.String());
            DropColumn("dbo.Adopcion", "FechaCreacion");
        }
    }
}
