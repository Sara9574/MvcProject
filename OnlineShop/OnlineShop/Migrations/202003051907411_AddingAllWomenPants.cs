namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAllWomenPants : DbMigration
    {
        public override void Up()
        {
            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,8,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',140000,N'شلوار پارچه‌ای گشاد')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/w746601_1.jpg',0),
                    (@currentId,'http://www.upsara.com/images/v587190_2.jpg',1),
                    (@currentId,'http://www.upsara.com/images/y547196_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/u041016_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,2,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',97000,N'شلوار جین دمپا گشاد')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/b432487_1.jpg',0),
                    (@currentId,'http://www.upsara.com/images/a835776_2.jpg',1),
                    (@currentId,'http://www.upsara.com/images/x671068_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/t083640_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,7,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',99500,N'شلوار پارچه‌ای گشاد')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/w898868_1.jpg',1),
                    (@currentId,'http://www.upsara.com/images/l008859_2.jpg',0),
                    (@currentId,'http://www.upsara.com/images/o836348_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/l610597_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,12,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',124000,N'شلوار پارچه‌ای کوتاه')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/c875351_1.jpg',1),
                    (@currentId,'http://www.upsara.com/images/t916793_2.jpg',0),
                    (@currentId,'http://www.upsara.com/images/w276030_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/z151267_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,9,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',167000,N'شلوار چرم کوتاه')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/f193933_1.jpg',0),
                    (@currentId,'http://www.upsara.com/images/y539851_2.jpg',1),
                    (@currentId,'http://www.upsara.com/images/s256161_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/n035707_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,6,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',136000,N'شلوار پارچه‌ای فاق بلند')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/k334763_1.jpg',1),
                    (@currentId,'http://www.upsara.com/images/b664448_2.jpg',0),
                    (@currentId,'http://www.upsara.com/images/v904611_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/a222633_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,3,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',136000,N'شلوار پارچه‌ای')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/b856927_1.jpg',0),
                    (@currentId,'http://www.upsara.com/images/t361411_2.jpg',1),
                    (@currentId,'http://www.upsara.com/images/y720523_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/m002366_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,9,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',113000,N'شلوار پارچه‌ای کوتاه')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/u121289_1.jpg',1),
                    (@currentId,'http://www.upsara.com/images/u916365_2.jpg',0),
                    (@currentId,'http://www.upsara.com/images/b199965_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/n644756_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,2,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',141500,N'شلوار پارچه‌ای کوتاه')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/a613352_1.jpg',0),
                    (@currentId,'http://www.upsara.com/images/g318392_2.jpg',1),
                    (@currentId,'http://www.upsara.com/images/t237129_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/n464597_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,1,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',95000,N'شلوار جین')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/r332865_1.jpg',0),
                    (@currentId,'http://www.upsara.com/images/o369617_2.jpg',0),
                    (@currentId,'http://www.upsara.com/images/x534970_3.jpg',1),
                    (@currentId,'http://www.upsara.com/images/v346782_4.jpg',0)");

            Sql(@"declare @currentId int;
                    insert into Item(SubCategoryId,ColorId,Desciption,Price,Title)
                    values (3,10,N'تنوع مدل های شلوار زنانه باعث شده است که هر شخص بنابر استایل شخصی خود بتواند شلوار زنانه مورد پسند خودرا پیدا کند.',135000,N'شلوار کوتاه راه راه')
                    SELECT @currentId=SCOPE_IDENTITY();
                    insert into [Image](ItemId,Link,IsMain)values
                    (@currentId,'http://www.upsara.com/images/d051567_1.jpg',1),
                    (@currentId,'http://www.upsara.com/images/y663505_2.jpg',0),
                    (@currentId,'http://www.upsara.com/images/q857562_3.jpg',0),
                    (@currentId,'http://www.upsara.com/images/o699834_4.jpg',0)");
        }
        
        public override void Down()
        {
        }
    }
}
