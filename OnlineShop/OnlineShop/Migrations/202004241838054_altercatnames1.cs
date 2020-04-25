namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altercatnames1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"update SubCategory
                set Title=N'شلوار' where id=6");
        }
        
        public override void Down()
        {
        }
    }
}
