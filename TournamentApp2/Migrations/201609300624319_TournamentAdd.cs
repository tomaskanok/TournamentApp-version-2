namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TournamentAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Web = c.String(),
                        Prize = c.Int(nullable: false),
                        Info = c.String(),
                        StartRegistration = c.DateTime(nullable: false),
                        EndRegistration = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        OrganizerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OrganizerId)
                .Index(t => t.OrganizerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournaments", "OrganizerId", "dbo.AspNetUsers");
            DropIndex("dbo.Tournaments", new[] { "OrganizerId" });
            DropTable("dbo.Tournaments");
        }
    }
}
