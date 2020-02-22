namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceIsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubmissionDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        InvoiceStateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvoiceState", t => t.InvoiceStateId, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.InvoiceStateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice", "UserId", "dbo.User");
            DropForeignKey("dbo.Invoice", "InvoiceStateId", "dbo.InvoiceState");
            DropIndex("dbo.Invoice", new[] { "InvoiceStateId" });
            DropIndex("dbo.Invoice", new[] { "UserId" });
            DropTable("dbo.Invoice");
        }
    }
}
