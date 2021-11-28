namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fivvee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "DailyPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Rentals", "RentPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "RentPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Rentals", "DailyPrice");
        }
    }
}
