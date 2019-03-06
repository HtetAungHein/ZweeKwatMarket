namespace ZweeKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ImagePath", c => c.String());
        }
    }
}
