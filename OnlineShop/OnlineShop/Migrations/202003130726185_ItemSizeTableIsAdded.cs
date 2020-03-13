namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemSizeTableIsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemSize",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: false)
                .ForeignKey("dbo.Size", t => t.SizeId, cascadeDelete: false)
                .Index(t => t.ItemId)
                .Index(t => t.SizeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemSize", "SizeId", "dbo.Size");
            DropForeignKey("dbo.ItemSize", "ItemId", "dbo.Item");
            DropIndex("dbo.ItemSize", new[] { "SizeId" });
            DropIndex("dbo.ItemSize", new[] { "ItemId" });
            DropTable("dbo.ItemSize");
        }
    }
}
