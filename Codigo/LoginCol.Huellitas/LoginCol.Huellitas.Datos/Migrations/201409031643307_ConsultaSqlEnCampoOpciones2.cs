namespace LoginCol.Huellitas.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsultaSqlEnCampoOpciones2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OpcionCampo", "Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OpcionCampo", "Valor", c => c.Int(nullable: false));
        }
    }
}
