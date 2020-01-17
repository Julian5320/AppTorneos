namespace AppTorneos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id_usuario_en_empresa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empresas", "id_Usuario", c => c.String());
            DropColumn("dbo.Equipoes", "id_Usuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipoes", "id_Usuario", c => c.String());
            DropColumn("dbo.Empresas", "id_Usuario");
        }
    }
}
