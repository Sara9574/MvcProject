namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAllItemsAndInvoices : DbMigration
    {
        public override void Up()
        {
            Sql(@"delete from invoiceItem
                  delete from invoice
                  delete from item");
        }
        
        public override void Down()
        {
        }
    }
}
