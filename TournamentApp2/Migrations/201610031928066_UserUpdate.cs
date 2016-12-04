namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SexMale", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "Weight", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "TeamId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "TeamConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Teams", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "TeamId");
            AddForeignKey("dbo.AspNetUsers", "TeamId", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "TeamId", "dbo.Teams");
            DropIndex("dbo.AspNetUsers", new[] { "TeamId" });
            DropColumn("dbo.Teams", "Discriminator");
            DropColumn("dbo.AspNetUsers", "TeamConfirmed");
            DropColumn("dbo.AspNetUsers", "TeamId");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Weight");
            DropColumn("dbo.AspNetUsers", "SexMale");
        }
    }
}
