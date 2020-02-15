namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageTableIsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Link = c.String(),
                    ImageTypeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageType", t => t.ImageTypeId, cascadeDelete: false)
                .Index(t => t.ImageTypeId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "ImageTypeId", "dbo.ImageType");
            DropIndex("dbo.Image", new[] { "ImageTypeId" });
            DropTable("dbo.Image");
        }
    }
}
