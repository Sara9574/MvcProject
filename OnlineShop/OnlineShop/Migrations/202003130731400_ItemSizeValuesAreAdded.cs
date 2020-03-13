namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ItemSizeValuesAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into ItemSize
                select Item.id,size.Id
                from item,size");
        }

        public override void Down()
        {
        }
    }
}
