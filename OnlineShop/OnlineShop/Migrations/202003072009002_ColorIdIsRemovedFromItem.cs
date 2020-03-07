namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColorIdIsRemovedFromItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "ColorId", "dbo.Color");
            DropIndex("dbo.Item", new[] { "ColorId" });
            DropColumn("dbo.Item", "ColorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "ColorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "ColorId");
            AddForeignKey("dbo.Item", "ColorId", "dbo.Color", "Id", cascadeDelete: false);
        }
    }
}
