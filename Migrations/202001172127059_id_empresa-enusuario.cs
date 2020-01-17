namespace AppTorneos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id_empresaenusuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "empresa_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "empresa_id");
        }
    }
}
