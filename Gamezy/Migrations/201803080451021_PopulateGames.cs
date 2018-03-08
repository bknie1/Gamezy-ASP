namespace Gamezy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGames : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Games(Name) VALUES ('Heroes of the Storm')");
            Sql("INSERT INTO Games(Name) VALUES ('Overwatch')");
            Sql("INSERT INTO Games(Name) VALUES ('World of Warcraft')");
            Sql("INSERT INTO Games(Name) VALUES ('Monster Hunter World')");
            Sql("INSERT INTO Games(Name) VALUES ('Shenmue')");
            Sql("INSERT INTO Games(Name) VALUES ('Half-Life')");
            Sql("INSERT INTO Games(Name) VALUES ('Counter-Strike')");
            Sql("INSERT INTO Games(Name) VALUES ('Doom')");
            Sql("INSERT INTO Games(Name) VALUES ('Commander Keen')");
            Sql("INSERT INTO Games(Name) VALUES ('Wolf 3D')");
            Sql("INSERT INTO Games(Name) VALUES ('Dota')");
            Sql("INSERT INTO Games(Name) VALUES ('Fortnite')");
            Sql("INSERT INTO Games(Name) VALUES ('Sonic Adventure')");
            Sql("INSERT INTO Games(Name) VALUES ('Titanfall')");
            Sql("INSERT INTO Games(Name) VALUES ('Halo')");
            Sql("INSERT INTO Games(Name) VALUES ('Starcraft 2')");
            Sql("INSERT INTO Games(Name) VALUES ('Diablo 3')");
        }

        public override void Down()
        {
        }
    }
}
