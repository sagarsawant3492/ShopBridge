namespace ShopBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeImageFieldType : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Products", "Image", c => c.());
            Sql("ALTER TABLE Products ALTER COLUMN Image varbinary(max)");
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Products", "Image", c => c.Binary());
        }
    }
}
