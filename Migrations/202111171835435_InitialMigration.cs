namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        EngineType = c.String(),
                        IsAutomatic = c.Boolean(nullable: false),
                        YearOfManufacture = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fname = c.String(),
                        Lname = c.String(),
                        Age = c.DateTime(nullable: false),
                        City = c.String(),
                        PostCode = c.Long(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        DailyPrice = c.Double(nullable: false),
                        WeaklyPrice = c.Double(nullable: false),
                        IsAutomatic = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        RentedFromThisDate = c.DateTime(nullable: false),
                        RentedToThisDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rentals");
            DropTable("dbo.Customers");
            DropTable("dbo.Cars");
        }
    }
}
