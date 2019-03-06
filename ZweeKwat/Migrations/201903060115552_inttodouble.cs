namespace ZweeKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inttodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "SubTotal", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "Taxes", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "DeliveryFee", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "ServiceCharges", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "ServiceCharges", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "DeliveryFee", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Taxes", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "SubTotal", c => c.Int(nullable: false));
        }
    }
}
