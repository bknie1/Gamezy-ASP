namespace Gamezy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberships : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Memberships (Id, SignUpFee, DurationMonth, DiscountRate) VALUES (0, 0, 0, 0)");
            Sql("INSERT INTO Memberships (Id, SignUpFee, DurationMonth, DiscountRate) VALUES (1, 5, 1, 10)");
            Sql("INSERT INTO Memberships (Id, SignUpFee, DurationMonth, DiscountRate) VALUES (2, 50, 12, 10)");
        }
        
        public override void Down()
        {
        }
    }
}
