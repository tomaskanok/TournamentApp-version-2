namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Paid = c.Boolean(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        TournamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TournamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Registrations", "TournamentId", "dbo.Tournaments");
            DropIndex("dbo.Registrations", new[] { "TournamentId" });
            DropIndex("dbo.Registrations", new[] { "UserId" });
            DropTable("dbo.Registrations");
        }
    }
}
