namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageTypeIsRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Image", "ImageTypeId", "dbo.ImageType");
            DropIndex("dbo.Image", new[] { "ImageTypeId" });
            DropColumn("dbo.Image", "ImageTypeId");
            DropTable("dbo.ImageType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Image", "ImageTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Image", "ImageTypeId");
            AddForeignKey("dbo.Image", "ImageTypeId", "dbo.ImageType", "Id", cascadeDelete: true);
        }
    }
}
