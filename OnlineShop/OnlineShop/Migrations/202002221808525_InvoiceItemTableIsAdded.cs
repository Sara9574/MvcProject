namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceItemTableIsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        EachItemPrice = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: false)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: false)
                .Index(t => t.InvoiceId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.InvoiceItem", "InvoiceId", "dbo.Invoice");
            DropIndex("dbo.InvoiceItem", new[] { "ItemId" });
            DropIndex("dbo.InvoiceItem", new[] { "InvoiceId" });
            DropTable("dbo.InvoiceItem");
        }
    }
}
