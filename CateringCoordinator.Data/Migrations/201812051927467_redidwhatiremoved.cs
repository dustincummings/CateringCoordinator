namespace CateringCoordinator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redidwhatiremoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Food", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Food", "Ingrediants", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Food", "Ingrediants", c => c.String());
            AlterColumn("dbo.Food", "Description", c => c.String());
            AlterColumn("dbo.Customer", "FirstName", c => c.String());
        }
    }
}
