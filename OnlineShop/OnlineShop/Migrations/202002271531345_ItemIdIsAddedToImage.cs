namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemIdIsAddedToImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Image", "ItemId", c => c.Int());
            AddColumn("dbo.Image", "IsMain", c => c.Boolean());
            CreateIndex("dbo.Image", "ItemId");
            AddForeignKey("dbo.Image", "ItemId", "dbo.Item", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "ItemId", "dbo.Item");
            DropIndex("dbo.Image", new[] { "ItemId" });
            DropColumn("dbo.Image", "IsMain");
            DropColumn("dbo.Image", "ItemId");
        }
    }
}
