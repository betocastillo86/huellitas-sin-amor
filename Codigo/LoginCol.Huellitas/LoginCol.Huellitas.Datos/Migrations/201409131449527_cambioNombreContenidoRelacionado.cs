namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioNombreContenidoRelacionado : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ContenidoRelacionado", name: "ContenidoPadreId", newName: "ContenidoHijoId");
            RenameIndex(table: "dbo.ContenidoRelacionado", name: "IX_ContenidoPadreId", newName: "IX_ContenidoHijoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ContenidoRelacionado", name: "IX_ContenidoHijoId", newName: "IX_ContenidoPadreId");
            RenameColumn(table: "dbo.ContenidoRelacionado", name: "ContenidoHijoId", newName: "ContenidoPadreId");
        }
    }
}
