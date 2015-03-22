namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterBarrio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FormularioAdopcion", "Barrio", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FormularioAdopcion", "Barrio", c => c.String());
        }
    }
}
