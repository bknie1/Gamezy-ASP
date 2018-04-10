namespace Gamezy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerDescMembershipAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Description", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Description", c => c.String());
        }
    }
}
