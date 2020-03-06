namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemColorTableIsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemColor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        IsMain = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Color", t => t.ColorId, cascadeDelete: false)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: false)
                .Index(t => t.ItemId)
                .Index(t => t.ColorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemColor", "ItemId", "dbo.Item");
            DropForeignKey("dbo.ItemColor", "ColorId", "dbo.Color");
            DropIndex("dbo.ItemColor", new[] { "ColorId" });
            DropIndex("dbo.ItemColor", new[] { "ItemId" });
            DropTable("dbo.ItemColor");
        }
    }
}
