namespace CateringCoordinator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undidpreviousadditions : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Food", "PreferredEvent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Food", "PreferredEvent", c => c.Int());
        }
    }
}
