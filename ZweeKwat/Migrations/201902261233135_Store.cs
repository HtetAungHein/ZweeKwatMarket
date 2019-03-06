namespace ZweeKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Store : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "ImagePath");
        }
    }
}
