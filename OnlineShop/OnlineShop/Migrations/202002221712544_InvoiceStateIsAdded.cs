namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceStateIsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceState",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InvoiceState");
        }
    }
}
