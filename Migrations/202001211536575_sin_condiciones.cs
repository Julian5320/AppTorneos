namespace AppTorneos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sin_condiciones : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MarcadorUsers", "id_partido_id", "dbo.Partidoes");
            DropForeignKey("dbo.MarcadorUsers", "id_torneo_id", "dbo.Torneos");
            DropForeignKey("dbo.MarcadorUsers", "id_user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MarcadorUsers", new[] { "id_partido_id" });
            DropIndex("dbo.MarcadorUsers", new[] { "id_torneo_id" });
            DropIndex("dbo.MarcadorUsers", new[] { "id_user_Id" });
            AddColumn("dbo.MarcadorUsers", "id_user", c => c.String());
            AddColumn("dbo.MarcadorUsers", "id_partido", c => c.String());
            AddColumn("dbo.MarcadorUsers", "id_torneo", c => c.String());
            DropColumn("dbo.MarcadorUsers", "id_partido_id");
            DropColumn("dbo.MarcadorUsers", "id_torneo_id");
            DropColumn("dbo.MarcadorUsers", "id_user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MarcadorUsers", "id_user_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.MarcadorUsers", "id_torneo_id", c => c.Int());
            AddColumn("dbo.MarcadorUsers", "id_partido_id", c => c.Int());
            DropColumn("dbo.MarcadorUsers", "id_torneo");
            DropColumn("dbo.MarcadorUsers", "id_partido");
            DropColumn("dbo.MarcadorUsers", "id_user");
            CreateIndex("dbo.MarcadorUsers", "id_user_Id");
            CreateIndex("dbo.MarcadorUsers", "id_torneo_id");
            CreateIndex("dbo.MarcadorUsers", "id_partido_id");
            AddForeignKey("dbo.MarcadorUsers", "id_user_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.MarcadorUsers", "id_torneo_id", "dbo.Torneos", "id");
            AddForeignKey("dbo.MarcadorUsers", "id_partido_id", "dbo.Partidoes", "id");
        }
    }
}
