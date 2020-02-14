namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategoryTableIsAltered : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubCategory", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubCategory", "CategoryId");
            AddForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category");
            DropIndex("dbo.SubCategory", new[] { "CategoryId" });
            DropColumn("dbo.SubCategory", "CategoryId");
        }
    }
}
