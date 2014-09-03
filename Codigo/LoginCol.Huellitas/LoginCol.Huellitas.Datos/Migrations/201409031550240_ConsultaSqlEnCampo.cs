namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultaSqlEnCampo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campo", "ConsultaSql", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campo", "ConsultaSql");
        }
    }
}
