namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColorCodeValuesAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"update color set ColorCode='#0213c9' where id=1
                    update color set ColorCode='#0a0d33' where id=2
                    update color set ColorCode='#d62109' where id=3
                    update color set ColorCode='#eaf525' where id=4
                    update color set ColorCode='#461063' where id=5
                    update color set ColorCode='#e336b8' where id=6
                    update color set ColorCode='#0a8f17' where id=7
                    update color set ColorCode='#4a290a' where id=8
                    update color set ColorCode='#000000' where id=9
                    update color set ColorCode='#ffffff' where id=10
                    update color set ColorCode='#ff8605' where id=11
                    update color set ColorCode='#757575' where id=12
                    update color set ColorCode='#757575' where id=13");
        }
        
        public override void Down()
        {
        }
    }
}
