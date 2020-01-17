namespace AppTorneos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id_usuario_en_equipo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipoes", "id_Usuario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipoes", "id_Usuario");
        }
    }
}
