namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MantoIsRemoved : DbMigration
    {
        public override void Up()
        {
            Sql(@"delete from SubCategory where id=2");
        }
        
        public override void Down()
        {
        }
    }
}
