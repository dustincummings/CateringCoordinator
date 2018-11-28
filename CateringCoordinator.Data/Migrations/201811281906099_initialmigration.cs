namespace CateringCoordinator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        PrepArea = c.Boolean(nullable: false),
                        NumOfGuest = c.Int(nullable: false),
                        NumOfHelpers = c.Int(nullable: false),
                        SuppliesNeeded = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        IsFullService = c.Boolean(nullable: false),
                        DateOfEvent = c.DateTime(nullable: false),
                        CostOfEvent = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Ingrediants = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Allergens = c.Boolean(nullable: false),
                        Servings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateTable(
                "dbo.FoodEvent",
                c => new
                    {
                        Food_FoodId = c.Int(nullable: false),
                        Event_EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Food_FoodId, t.Event_EventId })
                .ForeignKey("dbo.Food", t => t.Food_FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.Event_EventId, cascadeDelete: true)
                .Index(t => t.Food_FoodId)
                .Index(t => t.Event_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodEvent", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.FoodEvent", "Food_FoodId", "dbo.Food");
            DropForeignKey("dbo.Event", "CustomerId", "dbo.Customer");
            DropIndex("dbo.FoodEvent", new[] { "Event_EventId" });
            DropIndex("dbo.FoodEvent", new[] { "Food_FoodId" });
            DropIndex("dbo.Event", new[] { "CustomerId" });
            DropTable("dbo.FoodEvent");
            DropTable("dbo.Food");
            DropTable("dbo.Event");
            DropTable("dbo.Customer");
        }
    }
}
