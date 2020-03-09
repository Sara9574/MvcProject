namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleValuesAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into role(id, title, tag) 
                  values (1, N'کاربر', 'User'),
                         (2, N'ادمین', 'Admin')");
        }
        
        public override void Down()
        {
        }
    }
}
