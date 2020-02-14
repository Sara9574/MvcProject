namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategoryValuesAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into SubCategory values
                    (1, N'زنانه', 'Women'),
                    (2, N'مردانه', 'Men'),
                    (3, N'بچگانه','Children')");
        }
        
        public override void Down()
        {
        }
    }
}
