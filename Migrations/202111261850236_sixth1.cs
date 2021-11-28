namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "age");
        }
    }
}
