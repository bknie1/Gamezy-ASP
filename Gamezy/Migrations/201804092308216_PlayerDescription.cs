namespace Gamezy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "Description");
        }
    }
}
