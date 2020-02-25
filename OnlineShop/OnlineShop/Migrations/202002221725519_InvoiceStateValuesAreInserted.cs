namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceStateValuesAreInserted : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into InvoiceState values
                (1,N'پیش فاکتور','preFactor'),
                (2,N'پرداخت شده','paid'),
                (3,N'پایان یافته','successful'),
                (4,N'ناموفق','failed')");
        }
        
        public override void Down()
        {
        }
    }
}
