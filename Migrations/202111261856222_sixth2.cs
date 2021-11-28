namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomersCars",
                c => new
                    {
                        Customers_Id = c.Int(nullable: false),
                        Cars_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customers_Id, t.Cars_Id })
                .ForeignKey("dbo.Customers", t => t.Customers_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Cars_Id, cascadeDelete: true)
                .Index(t => t.Customers_Id)
                .Index(t => t.Cars_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomersCars", "Cars_Id", "dbo.Cars");
            DropForeignKey("dbo.CustomersCars", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.CustomersCars", new[] { "Cars_Id" });
            DropIndex("dbo.CustomersCars", new[] { "Customers_Id" });
            DropTable("dbo.CustomersCars");
        }
    }
}
