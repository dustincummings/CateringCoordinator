namespace CateringCoordinator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "FirstName", c => c.String());
            AlterColumn("dbo.Food", "Description", c => c.String());
            AlterColumn("dbo.Food", "Ingrediants", c => c.String());
            DropColumn("dbo.Customer", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "FullName", c => c.String());
            AlterColumn("dbo.Food", "Ingrediants", c => c.String(nullable: false));
            AlterColumn("dbo.Food", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
        }
    }
}
