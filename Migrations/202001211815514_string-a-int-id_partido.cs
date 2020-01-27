namespace AppTorneos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringaintid_partido : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MarcadorUsers", "id_partido", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MarcadorUsers", "id_partido", c => c.String());
        }
    }
}
