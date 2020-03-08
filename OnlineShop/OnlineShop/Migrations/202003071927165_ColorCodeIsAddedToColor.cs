namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColorCodeIsAddedToColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Color", "ColorCode", c => c.String());
            DropColumn("dbo.ItemColor", "IsMain");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemColor", "IsMain", c => c.Boolean(nullable: false));
            DropColumn("dbo.Color", "ColorCode");
        }
    }
}
