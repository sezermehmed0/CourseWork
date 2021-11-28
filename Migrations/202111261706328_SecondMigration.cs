namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "SortableId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "Cars_Id", c => c.Int());
            AddColumn("dbo.Rentals", "Customers_Id", c => c.Int());
            AlterColumn("dbo.Cars", "Brand", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Cars", "Model", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Cars", "EngineType", c => c.String(nullable: false));
            AlterColumn("dbo.Rentals", "Brand", c => c.String(nullable: false));
            AlterColumn("dbo.Rentals", "Model", c => c.String(nullable: false));
            CreateIndex("dbo.Rentals", "Cars_Id");
            CreateIndex("dbo.Rentals", "Customers_Id");
            AddForeignKey("dbo.Rentals", "Cars_Id", "dbo.Cars", "Id");
            AddForeignKey("dbo.Rentals", "Customers_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Customers_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Cars_Id", "dbo.Cars");
            DropIndex("dbo.Rentals", new[] { "Customers_Id" });
            DropIndex("dbo.Rentals", new[] { "Cars_Id" });
            AlterColumn("dbo.Rentals", "Model", c => c.String());
            AlterColumn("dbo.Rentals", "Brand", c => c.String());
            AlterColumn("dbo.Cars", "EngineType", c => c.String());
            AlterColumn("dbo.Cars", "Model", c => c.String());
            AlterColumn("dbo.Cars", "Brand", c => c.String());
            DropColumn("dbo.Rentals", "Customers_Id");
            DropColumn("dbo.Rentals", "Cars_Id");
            DropColumn("dbo.Cars", "SortableId");
        }
    }
}
