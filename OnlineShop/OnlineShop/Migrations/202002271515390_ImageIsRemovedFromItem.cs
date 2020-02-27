namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageIsRemovedFromItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "ImageId", "dbo.Image");
            DropIndex("dbo.Item", new[] { "ImageId" });
            DropColumn("dbo.Item", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "ImageId");
            AddForeignKey("dbo.Item", "ImageId", "dbo.Image", "Id", cascadeDelete: true);
        }
    }
}
