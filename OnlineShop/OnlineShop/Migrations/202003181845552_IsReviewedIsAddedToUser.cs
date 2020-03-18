namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsReviewedIsAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsReviewed", c => c.Boolean(nullable: false,defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsReviewed");
        }
    }
}
