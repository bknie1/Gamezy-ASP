namespace Gamezy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Genre");
        }
    }
}
