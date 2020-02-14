namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemTableIsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubCategoryId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Title = c.String(),
                        Desciption = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategory", t => t.SubCategoryId, cascadeDelete: false)
                .Index(t => t.SubCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "SubCategoryId", "dbo.SubCategory");
            DropIndex("dbo.Item", new[] { "SubCategoryId" });
            DropTable("dbo.Item");
        }
    }
}
