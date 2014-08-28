namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SubtipoContenido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoContenido", "TipoContenidoPadreId", c => c.Int());
            AddColumn("dbo.TipoContenido", "TipoContenidoPadre_TipoContenidoId", c => c.Int());
            CreateIndex("dbo.TipoContenido", "TipoContenidoPadre_TipoContenidoId");
            AddForeignKey("dbo.TipoContenido", "TipoContenidoPadre_TipoContenidoId", "dbo.TipoContenido", "TipoContenidoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoContenido", "TipoContenidoPadre_TipoContenidoId", "dbo.TipoContenido");
            DropIndex("dbo.TipoContenido", new[] { "TipoContenidoPadre_TipoContenidoId" });
            DropColumn("dbo.TipoContenido", "TipoContenidoPadre_TipoContenidoId");
            DropColumn("dbo.TipoContenido", "TipoContenidoPadreId");
        }
    }
}
