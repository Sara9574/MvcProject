namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColorIdIsAddedToItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Item", "ColorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "ColorId");
            AddForeignKey("dbo.Item", "ColorId", "dbo.Color", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "ColorId", "dbo.Color");
            DropIndex("dbo.Item", new[] { "ColorId" });
            DropColumn("dbo.Item", "ColorId");
            DropTable("dbo.Color");
        }
    }
}
