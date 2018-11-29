namespace CateringCoordinator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "EventId", c => c.Int(nullable: false));
        }
    }
}
