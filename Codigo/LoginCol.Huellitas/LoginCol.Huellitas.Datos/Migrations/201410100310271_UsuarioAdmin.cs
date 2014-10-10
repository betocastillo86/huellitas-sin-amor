namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "EsAdministrador", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "EsAdministrador");
        }
    }
}
