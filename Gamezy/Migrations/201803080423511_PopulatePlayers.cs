namespace Gamezy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePlayers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Players(Name, NewsletterSubscription, MembershipId) VALUES ('Brandon', 'FALSE', 0)");
            Sql("INSERT INTO Players(Name, NewsletterSubscription, MembershipId) VALUES ('Yilan', 'TRUE', 0)");
            Sql("INSERT INTO Players(Name, NewsletterSubscription, MembershipId) VALUES ('Philip', 'TRUE', 0)");
            Sql("INSERT INTO Players(Name, NewsletterSubscription, MembershipId) VALUES ('Chrissy', 'TRUE', 0)");
        }
        
        public override void Down()
        {
        }
    }
}
