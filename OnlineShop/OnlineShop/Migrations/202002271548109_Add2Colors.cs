namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add2Colors : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into color(Id,Title,Tag) values 
                (12,N'طوسی','grey'),
                (13,N'چند رنگ','multi-color')");
        }
        
        public override void Down()
        {
        }
    }
}
