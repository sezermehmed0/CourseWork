namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yolo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomersCars", "Customers_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomersCars", "Cars_Id", "dbo.Cars");
            DropIndex("dbo.CustomersCars", new[] { "Customers_Id" });
            DropIndex("dbo.CustomersCars", new[] { "Cars_Id" });
            AddColumn("dbo.Customers", "Cars_Id", c => c.Int());
            AlterColumn("dbo.Customers", "Lname", c => c.String(maxLength: 30));
            AlterColumn("dbo.Customers", "City", c => c.String(maxLength: 30));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.Long());
            CreateIndex("dbo.Customers", "Cars_Id");
            AddForeignKey("dbo.Customers", "Cars_Id", "dbo.Cars", "Id");
            DropTable("dbo.CustomersCars");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomersCars",
                c => new
                    {
                        Customers_Id = c.Int(nullable: false),
                        Cars_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customers_Id, t.Cars_Id });
            
            DropForeignKey("dbo.Customers", "Cars_Id", "dbo.Cars");
            DropIndex("dbo.Customers", new[] { "Cars_Id" });
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "Lname", c => c.String());
            DropColumn("dbo.Customers", "Cars_Id");
            CreateIndex("dbo.CustomersCars", "Cars_Id");
            CreateIndex("dbo.CustomersCars", "Customers_Id");
            AddForeignKey("dbo.CustomersCars", "Cars_Id", "dbo.Cars", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomersCars", "Customers_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
