namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn_Token_Table_FormularioAdopcion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormularioAdopcion", "TokenAutorespuesta", c => c.Guid(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormularioAdopcion", "TokenAutorespuesta");
        }
    }
}
