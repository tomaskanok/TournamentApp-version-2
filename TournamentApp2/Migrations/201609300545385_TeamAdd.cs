namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LeaderId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LeaderId, cascadeDelete: true)
                .Index(t => t.LeaderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "LeaderId", "dbo.AspNetUsers");
            DropIndex("dbo.Teams", new[] { "LeaderId" });
            DropTable("dbo.Teams");
        }
    }
}
