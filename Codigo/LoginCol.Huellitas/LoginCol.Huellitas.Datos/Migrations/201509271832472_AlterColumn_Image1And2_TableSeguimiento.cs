namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumn_Image1And2_TableSeguimiento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SeguimientoAdopcion", "Imagen1", c => c.Boolean(nullable: false, defaultValue:false));
            AlterColumn("dbo.SeguimientoAdopcion", "Imagen2", c => c.Boolean(nullable: false, defaultValue:false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SeguimientoAdopcion", "Imagen2", c => c.String(maxLength: 300));
            AlterColumn("dbo.SeguimientoAdopcion", "Imagen1", c => c.String(maxLength: 300));
        }
    }
}
