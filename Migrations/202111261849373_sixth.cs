namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Fname", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "PostCode", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Age", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "PostCode", c => c.Long(nullable: false));
            AlterColumn("dbo.Customers", "Fname", c => c.String());
        }
    }
}
