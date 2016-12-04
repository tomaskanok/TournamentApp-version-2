namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FightAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Result = c.String(),
                        TimeEnd = c.DateTime(),
                        Overtime = c.Boolean(),
                        WayOfWin = c.String(),
                        PointsFirst = c.Int(),
                        PointsSecond = c.Int(),
                        ApplicationUserRefereeId = c.String(maxLength: 128),
                        ApplicationUserFighterFirstId = c.String(maxLength: 128),
                        ApplicationUserFighterSecondId = c.String(maxLength: 128),
                        RootFightId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserFighterFirstId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserFighterSecondId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserRefereeId)
                .ForeignKey("dbo.Fights", t => t.RootFightId)
                .Index(t => t.ApplicationUserRefereeId)
                .Index(t => t.ApplicationUserFighterFirstId)
                .Index(t => t.ApplicationUserFighterSecondId)
                .Index(t => t.RootFightId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fights", "RootFightId", "dbo.Fights");
            DropForeignKey("dbo.Fights", "ApplicationUserRefereeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Fights", "ApplicationUserFighterSecondId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Fights", "ApplicationUserFighterFirstId", "dbo.AspNetUsers");
            DropIndex("dbo.Fights", new[] { "RootFightId" });
            DropIndex("dbo.Fights", new[] { "ApplicationUserFighterSecondId" });
            DropIndex("dbo.Fights", new[] { "ApplicationUserFighterFirstId" });
            DropIndex("dbo.Fights", new[] { "ApplicationUserRefereeId" });
            DropTable("dbo.Fights");
        }
    }
}
