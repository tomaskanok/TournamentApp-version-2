namespace TournamentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teams", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
