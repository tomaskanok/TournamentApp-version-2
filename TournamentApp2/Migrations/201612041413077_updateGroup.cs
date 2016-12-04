namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "RegistrationId", "dbo.Registrations");
            DropIndex("dbo.Groups", new[] { "RegistrationId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Groups", "RegistrationId");
            AddForeignKey("dbo.Groups", "RegistrationId", "dbo.Registrations", "Id", cascadeDelete: true);
        }
    }
}
