namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackTableIsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                        UserId = c.Int(nullable: false),
                        Description = c.String(),
                        Rate = c.Double(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                        IsVerified = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.ItemId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedback", "UserId", "dbo.User");
            DropForeignKey("dbo.Feedback", "ItemId", "dbo.Item");
            DropIndex("dbo.Feedback", new[] { "UserId" });
            DropIndex("dbo.Feedback", new[] { "ItemId" });
            DropTable("dbo.Feedback");
        }
    }
}
