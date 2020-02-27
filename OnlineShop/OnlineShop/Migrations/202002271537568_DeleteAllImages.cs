namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAllImages : DbMigration
    {
        public override void Up()
        {
            Sql(@"delete from [Image]");
        }
        
        public override void Down()
        {
        }
    }
}
