namespace AppTorneos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class torneo_partido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partidoes", "torneo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Partidoes", "torneo");
        }
    }
}
