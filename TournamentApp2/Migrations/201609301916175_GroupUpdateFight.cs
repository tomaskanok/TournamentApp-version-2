namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupUpdateFight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "FinalFight", c => c.Int());
            CreateIndex("dbo.Groups", "FinalFight");
            AddForeignKey("dbo.Groups", "FinalFight", "dbo.Fights", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "FinalFight", "dbo.Fights");
            DropIndex("dbo.Groups", new[] { "FinalFight" });
            DropColumn("dbo.Groups", "FinalFight");
        }
    }
}
