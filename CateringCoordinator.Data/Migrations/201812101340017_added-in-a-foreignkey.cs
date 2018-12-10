namespace CateringCoordinator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedinaforeignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food", "PreferredEvent", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food", "PreferredEvent");
        }
    }
}
