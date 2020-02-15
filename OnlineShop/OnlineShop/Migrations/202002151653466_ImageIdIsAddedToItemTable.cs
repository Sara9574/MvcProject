namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageIdIsAddedToItemTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "ImageId");
            AddForeignKey("dbo.Item", "ImageId", "dbo.Image", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "ImageId", "dbo.Image");
            DropIndex("dbo.Item", new[] { "ImageId" });
            DropColumn("dbo.Item", "ImageId");
        }
    }
}
