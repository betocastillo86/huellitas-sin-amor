namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZonaUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "ZonaGeograficaId", c => c.Int());
            AlterColumn("dbo.DatoTablaBasica", "PadreId", c => c.Int());
            CreateIndex("dbo.Usuario", "ZonaGeograficaId");
            AddForeignKey("dbo.Usuario", "ZonaGeograficaId", "dbo.ZonaGeografica", "ZonaGeograficaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "ZonaGeograficaId", "dbo.ZonaGeografica");
            DropIndex("dbo.Usuario", new[] { "ZonaGeograficaId" });
            AlterColumn("dbo.DatoTablaBasica", "PadreId", c => c.Int(nullable: false));
            DropColumn("dbo.Usuario", "ZonaGeograficaId");
        }
    }
}
