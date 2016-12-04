namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationUpdateGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Registrations", "GroupId");
            AddForeignKey("dbo.Registrations", "GroupId", "dbo.Groups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "GroupId", "dbo.Groups");
            DropIndex("dbo.Registrations", new[] { "GroupId" });
            DropColumn("dbo.Registrations", "GroupId");
        }
    }
}
