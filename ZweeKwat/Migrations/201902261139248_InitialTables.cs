namespace ZweeKwat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        CategoryID = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        StoreID = c.Guid(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        OrderID = c.Guid(nullable: false),
                        ProductID = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        SubTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CustomerID = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        Taxes = c.Int(nullable: false),
                        DeliveryFee = c.Int(nullable: false),
                        ServiceCharges = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        StoreName = c.String(),
                        OwnerName = c.String(),
                        NRC = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "StoreID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Stores");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
