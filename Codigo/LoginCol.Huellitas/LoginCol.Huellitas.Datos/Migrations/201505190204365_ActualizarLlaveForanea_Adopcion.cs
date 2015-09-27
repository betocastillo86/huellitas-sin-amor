namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarLlaveForanea_Adopcion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adopcion", "AdopcionId", "dbo.FormularioAdopcion");
            DropForeignKey("dbo.FormularioAdopcion", "FormularioAdopcionId", "dbo.Adopcion");
            DropForeignKey("dbo.SeguimientoAdopcion", "AdopcionId", "dbo.Adopcion");
            DropForeignKey("dbo.RespuestaAdopcion", "FormularioAdopcionId", "dbo.FormularioAdopcion");
            DropIndex("dbo.Adopcion", new[] { "AdopcionId" });
            DropPrimaryKey("dbo.Adopcion");
            DropPrimaryKey("dbo.FormularioAdopcion");
            AlterColumn("dbo.Adopcion", "AdopcionId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.FormularioAdopcion", "FormularioAdopcionId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Adopcion", "AdopcionId");
            AddPrimaryKey("dbo.FormularioAdopcion", "FormularioAdopcionId");
            CreateIndex("dbo.FormularioAdopcion", "FormularioAdopcionId");
            AddForeignKey("dbo.FormularioAdopcion", "FormularioAdopcionId", "dbo.Adopcion", "AdopcionId");
            AddForeignKey("dbo.SeguimientoAdopcion", "AdopcionId", "dbo.Adopcion", "AdopcionId");
            AddForeignKey("dbo.RespuestaAdopcion", "FormularioAdopcionId", "dbo.FormularioAdopcion", "FormularioAdopcionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RespuestaAdopcion", "FormularioAdopcionId", "dbo.FormularioAdopcion");
            DropForeignKey("dbo.SeguimientoAdopcion", "AdopcionId", "dbo.Adopcion");
            DropForeignKey("dbo.FormularioAdopcion", "FormularioAdopcionId", "dbo.Adopcion");
            DropIndex("dbo.FormularioAdopcion", new[] { "FormularioAdopcionId" });
            DropPrimaryKey("dbo.FormularioAdopcion");
            DropPrimaryKey("dbo.Adopcion");
            AlterColumn("dbo.FormularioAdopcion", "FormularioAdopcionId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Adopcion", "AdopcionId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.FormularioAdopcion", "FormularioAdopcionId");
            AddPrimaryKey("dbo.Adopcion", "AdopcionId");
            CreateIndex("dbo.Adopcion", "AdopcionId");
            AddForeignKey("dbo.RespuestaAdopcion", "FormularioAdopcionId", "dbo.FormularioAdopcion", "FormularioAdopcionId", cascadeDelete: true);
            AddForeignKey("dbo.SeguimientoAdopcion", "AdopcionId", "dbo.Adopcion", "AdopcionId");
            AddForeignKey("dbo.FormularioAdopcion", "FormularioAdopcionId", "dbo.Adopcion", "AdopcionId");
            AddForeignKey("dbo.Adopcion", "AdopcionId", "dbo.FormularioAdopcion", "FormularioAdopcionId");
        }
    }
}
