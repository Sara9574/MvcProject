namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceSumIsAddedToTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoice", "InvoiceSum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoice", "InvoiceSum");
        }
    }
}
