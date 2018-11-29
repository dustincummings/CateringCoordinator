namespace CateringCoordinator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Customer", "EventId", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Food", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food", "OwnerId");
            DropColumn("dbo.Event", "OwnerId");
            DropColumn("dbo.Customer", "EventId");
            DropColumn("dbo.Customer", "OwnerId");
        }
    }
}
