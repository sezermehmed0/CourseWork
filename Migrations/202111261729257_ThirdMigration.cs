namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "RentPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Rentals", "IsAutomatic", c => c.Boolean());
            DropColumn("dbo.Rentals", "DailyPrice");
            DropColumn("dbo.Rentals", "WeaklyPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "WeaklyPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Rentals", "DailyPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Rentals", "IsAutomatic", c => c.Boolean(nullable: false));
            DropColumn("dbo.Rentals", "RentPrice");
        }
    }
}
