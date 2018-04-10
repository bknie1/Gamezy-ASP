namespace Gamezy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memberships", "Tier", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memberships", "Tier");
        }
    }
}
