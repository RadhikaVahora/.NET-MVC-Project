namespace OnBoardingTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeysOnBoarding_Proj1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SalesId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Sales", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "StoreId" });
            DropIndex("dbo.Sales", new[] { "ProductId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Products");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
        }
    }
}
