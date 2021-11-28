namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "HorsePower", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "HorsePower");
        }
    }
}
