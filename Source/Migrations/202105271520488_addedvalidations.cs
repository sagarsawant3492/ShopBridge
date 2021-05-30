namespace ShopBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvalidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductCode", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Image", c => c.String());
            AlterColumn("dbo.Products", "ProductCode", c => c.String());
        }
    }
}
