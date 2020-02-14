namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryValuesAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into Category values
                    (1,N'زنانه','Women'),
                    (2,N'شلوار','Men'),
                    (3,N'بچگانه','Children')
                    ");
        }
        
        public override void Down()
        {
        }
    }
}
