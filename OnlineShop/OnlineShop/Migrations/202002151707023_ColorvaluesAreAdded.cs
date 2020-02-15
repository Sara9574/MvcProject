namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColorvaluesAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[Color]
            ([Id]
            ,[Title]
            ,[Tag])
         VALUES
            (1,N'آبی','blue'),
		    (2,N'سرمه‌ای','dark blue'),
		    (3,N'قرمز','red'),
		    (4,N'زرد','yellow'),
		    (5,N'بنفش','purple'),
		    (6,N'صورتی','pink'),
		    (7,N'سبز','green'),
		    (8,N'قهوه‌ای','brown'),
		    (9,N'مشکی','black'),
		    (10,N'سفید','white'),
		    (11,N'نارنجی','orange')");
        }
        
        public override void Down()
        {
        }
    }
}
