namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertOnePantsItem : DbMigration
    {
        public override void Up()
        {
            Sql(@"declare @currentId int;
                  insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                  values (3,9,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',119000,N'شلوار جین کوتاه')
                  SELECT @currentId=SCOPE_IDENTITY();
                  insert into [Image](ItemId,Link,IsMain)values
                  (@currentId,'http://www.upsara.com/images/z129444_1.jpg',0),
                  (@currentId,'http://www.upsara.com/images/g868251_2.jpg',1),
                  (@currentId,'http://www.upsara.com/images/p833180_3.jpg',0),
                  (@currentId,'http://www.upsara.com/images/h758067_4.jpg',0)");
        }
        
        public override void Down()
        {
        }
    }
}
