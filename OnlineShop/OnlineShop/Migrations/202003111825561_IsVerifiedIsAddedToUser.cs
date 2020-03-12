namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsVerifiedIsAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsVerified", c => c.Boolean(nullable: false, defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsVerified");
        }
    }
}
