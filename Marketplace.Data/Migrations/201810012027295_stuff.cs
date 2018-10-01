namespace Marketplace.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "RetailerId", "dbo.Retailer");
            DropIndex("dbo.Product", new[] { "RetailerId" });
            DropColumn("dbo.Product", "ProductProfit");
            DropColumn("dbo.Product", "ProductOnSale");
            DropColumn("dbo.Product", "RetailerId");
            DropColumn("dbo.Product", "ProductImage");
            DropColumn("dbo.Retailer", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Retailer", "Image", c => c.String());
            AddColumn("dbo.Product", "ProductImage", c => c.String());
            AddColumn("dbo.Product", "RetailerId", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "ProductOnSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "ProductProfit", c => c.Double(nullable: false));
            CreateIndex("dbo.Product", "RetailerId");
            AddForeignKey("dbo.Product", "RetailerId", "dbo.Retailer", "RetailerId", cascadeDelete: true);
        }
    }
}
