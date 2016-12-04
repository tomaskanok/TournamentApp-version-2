namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddIdentify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ShortIdentify", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ShortIdentify");
        }
    }
}
