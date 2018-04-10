namespace Gamezy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "Birthday");
        }
    }
}
