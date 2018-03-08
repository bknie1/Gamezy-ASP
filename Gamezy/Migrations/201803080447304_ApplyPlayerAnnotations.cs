namespace Gamezy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyPlayerAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Name", c => c.String());
        }
    }
}
