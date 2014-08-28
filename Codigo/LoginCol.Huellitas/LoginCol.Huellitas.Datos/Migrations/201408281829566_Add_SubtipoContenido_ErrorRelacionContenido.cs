namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SubtipoContenido_ErrorRelacionContenido : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TipoContenido", "TipoContenidoPadreId");
            RenameColumn(table: "dbo.TipoContenido", name: "TipoContenidoPadre_TipoContenidoId", newName: "TipoContenidoPadreId");
            RenameIndex(table: "dbo.TipoContenido", name: "IX_TipoContenidoPadre_TipoContenidoId", newName: "IX_TipoContenidoPadreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TipoContenido", name: "IX_TipoContenidoPadreId", newName: "IX_TipoContenidoPadre_TipoContenidoId");
            RenameColumn(table: "dbo.TipoContenido", name: "TipoContenidoPadreId", newName: "TipoContenidoPadre_TipoContenidoId");
            AddColumn("dbo.TipoContenido", "TipoContenidoPadreId", c => c.Int());
        }
    }
}
