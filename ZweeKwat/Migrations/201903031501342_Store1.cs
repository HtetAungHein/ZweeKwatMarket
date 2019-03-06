namespace ZweeKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Store1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stores", "StoreName", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "OwnerName", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "NRC", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Address", c => c.String());
            AlterColumn("dbo.Stores", "Email", c => c.String());
            AlterColumn("dbo.Stores", "Phone", c => c.String());
            AlterColumn("dbo.Stores", "NRC", c => c.String());
            AlterColumn("dbo.Stores", "OwnerName", c => c.String());
            AlterColumn("dbo.Stores", "StoreName", c => c.String());
        }
    }
}
