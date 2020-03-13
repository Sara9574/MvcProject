namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SizeValuesAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into size(id,title,tag) values
               (1,'Small','S'),
               (2,'Medium','M'),
               (3,'Large','L'),
               (4,'Extra Large','X-L')");
        }

        public override void Down()
        {
        }
    }
}
