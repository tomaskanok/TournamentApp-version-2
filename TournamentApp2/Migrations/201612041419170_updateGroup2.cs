namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGroup2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Groups", "RegistrationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "RegistrationId", c => c.Int(nullable: false));
        }
    }
}
