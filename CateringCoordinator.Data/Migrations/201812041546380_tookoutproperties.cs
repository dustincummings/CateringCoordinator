namespace CateringCoordinator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tookoutproperties : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Event", "PrepArea");
            DropColumn("dbo.Event", "NumOfHelpers");
            DropColumn("dbo.Event", "SuppliesNeeded");
            DropColumn("dbo.Event", "IsFullService");
            DropColumn("dbo.Event", "CostOfEvent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "CostOfEvent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Event", "IsFullService", c => c.Boolean(nullable: false));
            AddColumn("dbo.Event", "SuppliesNeeded", c => c.String(nullable: false));
            AddColumn("dbo.Event", "NumOfHelpers", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "PrepArea", c => c.Boolean(nullable: false));
        }
    }
}
