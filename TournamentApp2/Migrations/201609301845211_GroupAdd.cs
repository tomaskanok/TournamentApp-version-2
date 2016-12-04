namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeightKg = c.Int(nullable: false),
                        SexMale = c.Boolean(nullable: false),
                        Belt = c.String(),
                        RegistrationId = c.Int(nullable: false),
                        TournamentId = c.Int(nullable: false),
                        ClosedRegistation = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId)
                .Index(t => t.RegistrationId)
                .Index(t => t.TournamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.Groups", "RegistrationId", "dbo.Registrations");
            DropIndex("dbo.Groups", new[] { "TournamentId" });
            DropIndex("dbo.Groups", new[] { "RegistrationId" });
            DropTable("dbo.Groups");
        }
    }
}
