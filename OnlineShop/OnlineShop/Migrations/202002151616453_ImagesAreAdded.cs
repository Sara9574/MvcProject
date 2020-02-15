namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ImagesAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into [image] values
                ('http://www.upsara.com/images/p991271_1.jpg'),
                ('http://www.upsara.com/images/r263274_2.jpg'),
                ('http://www.upsara.com/images/a785479_3.jpg'),
                ('http://www.upsara.com/images/p744442_4.jpg'),
                ('http://www.upsara.com/images/g886686_5.jpg'),
                ('http://www.upsara.com/images/x877119_6.jpg'),
                ('http://www.upsara.com/images/w669404_7.jpg'),
                ('http://www.upsara.com/images/p896345_8.jpg'),
                ('http://www.upsara.com/images/u040459_9.jpg'),
                ('http://www.upsara.com/images/o383718_10.jpg')");
        }

        public override void Down()
        {
        }
    }
}
