namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReorganizacionFormularioData3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "EstadoCivilId");
            DropColumn("dbo.Usuario", "OcupacionId");
            RenameColumn(table: "dbo.Usuario", name: "EstadoCivil_TablaBasicaId", newName: "EstadoCivilId");
            RenameColumn(table: "dbo.Usuario", name: "Ocupacion_TablaBasicaId", newName: "OcupacionId");
            RenameIndex(table: "dbo.Usuario", name: "IX_Ocupacion_TablaBasicaId", newName: "IX_OcupacionId");
            RenameIndex(table: "dbo.Usuario", name: "IX_EstadoCivil_TablaBasicaId", newName: "IX_EstadoCivilId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Usuario", name: "IX_EstadoCivilId", newName: "IX_EstadoCivil_TablaBasicaId");
            RenameIndex(table: "dbo.Usuario", name: "IX_OcupacionId", newName: "IX_Ocupacion_TablaBasicaId");
            RenameColumn(table: "dbo.Usuario", name: "OcupacionId", newName: "Ocupacion_TablaBasicaId");
            RenameColumn(table: "dbo.Usuario", name: "EstadoCivilId", newName: "EstadoCivil_TablaBasicaId");
            AddColumn("dbo.Usuario", "OcupacionId", c => c.Int());
            AddColumn("dbo.Usuario", "EstadoCivilId", c => c.Int());
        }
    }
}
