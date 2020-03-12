namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleIdIsAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "RoleId", c => c.Int(nullable: false, defaultValue:1));
            CreateIndex("dbo.User", "RoleId");
            AddForeignKey("dbo.User", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropIndex("dbo.User", new[] { "RoleId" });
            DropColumn("dbo.User", "RoleId");
        }
    }
}
