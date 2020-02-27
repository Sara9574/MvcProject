namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewSkirtsImagesAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into [Image](Link,itemId,isMain) values
                    ('https://www.upsara.com/images/e602279_1.jpg',1002,0),
                    ('https://www.upsara.com/images/p035452_2.jpg',1002,1),
                    ('https://www.upsara.com/images/m584283_3.jpg',1002,0),
                    ('https://www.upsara.com/images/l496507_4.jpg',1002,0),
                    
                    ('https://www.upsara.com/images/f236266_1.jpg',1003,0),
                    ('https://www.upsara.com/images/k553036_2.jpg',1003,1),
                    ('https://www.upsara.com/images/t684446_3.jpg',1003,0),
                    ('https://www.upsara.com/images/y374683_4.jpg',1003,0),
                    
                    
                    ('https://www.upsara.com/images/a990921_1.jpg',1004,0),
                    ('https://www.upsara.com/images/v878024_2.jpg',1004,1),
                    ('https://www.upsara.com/images/p662750_3.jpg',1004,0),
                    ('https://www.upsara.com/images/f912006_4.jpg',1004,0),
                    
                    ('https://www.upsara.com/images/d132882_1.jpg',1005,0),
                    ('https://www.upsara.com/images/o983538_2.jpg',1005,1),
                    ('https://www.upsara.com/images/y163341_3.jpg',1005,0),
                    ('https://www.upsara.com/images/l117686_4.jpg',1005,0),
                    
                    ('https://www.upsara.com/images/p374771_1.jpg',1006,0),
                    ('https://www.upsara.com/images/k886667_2.jpg',1006,0),
                    ('https://www.upsara.com/images/d114898_3.jpg',1006,0),
                    ('https://www.upsara.com/images/f513720_4.jpg',1006,1),
                    
                    ('https://www.upsara.com/images/a852514_1.jpg',1007,0),
                    ('https://www.upsara.com/images/x659136_2.jpg',1007,1),
                    ('https://www.upsara.com/images/g730053_3.jpg',1007,0),
                    ('https://www.upsara.com/images/q730517_4.jpg',1007,0),
                    
                    ('https://www.upsara.com/images/c629594_1.jpg',1008,0),
                    ('https://www.upsara.com/images/v226136_2.jpg',1008,1),
                    ('https://www.upsara.com/images/w098813_3.jpg',1008,0),
                    ('https://www.upsara.com/images/n142869_4.jpg',1008,0),
                    
                    ('https://www.upsara.com/images/u412469_1.jpg',1009,0),
                    ('https://www.upsara.com/images/g125358_2.jpg',1009,0),
                    ('https://www.upsara.com/images/s985582_3.jpg',1009,0),
                    ('https://www.upsara.com/images/t087487_4.jpg',1009,1),
                    
                    ('https://www.upsara.com/images/r314931_1.jpg',1010,0),
                    ('https://www.upsara.com/images/a094046_2.jpg',1010,1),
                    ('https://www.upsara.com/images/i588431_3.jpg',1010,0),
                    ('https://www.upsara.com/images/c072970_4.jpg',1010,0),
                    
                    ('https://www.upsara.com/images/h512600_1.jpg',1011,0),
                    ('https://www.upsara.com/images/s926424_2.jpg',1011,1),
                    ('https://www.upsara.com/images/k056539_3.jpg',1011,0),
                    ('https://www.upsara.com/images/i061348_4.jpg',1011,0)");
        }
        
        public override void Down()
        {
        }
    }
}
