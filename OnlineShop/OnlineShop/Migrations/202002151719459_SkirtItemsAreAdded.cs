namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkirtItemsAreAdded : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[Item]
           ([SubCategoryId]
           ,[Price]
           ,[Title]
           ,[Desciption]
           ,[ImageId]
           ,[ColorId])
     VALUES
           (4,94000,N'دامن تور دار',N'کاربرد مجلسی مهمانی و روزمره',1,2),
		   (4,55000,N'دامن کوتاه',N'کاربرد مجلسی مهمانی و روزمره',2,3),
		   (4,67000,N'دامن خط دار',N'کاربرد مجلسی مهمانی و روزمره',3,9),
		   (4,87000,N'دامن عروسکی',N'کاربرد مجلسی مهمانی و روزمره',4,6),
		   (4,43000,N'دامن کوتاه',N'کاربرد مجلسی مهمانی و روزمره',5,7),
		   (4,10200,N'دامن کوتاه',N'کاربرد مجلسی مهمانی و روزمره',6,1),
		   (4,66000,N'دامن تور دار',N'کاربرد مجلسی مهمانی و روزمره',7,3),
		   (4,53000,N'دامن کوتاه',N'کاربرد مجلسی مهمانی و روزمره',8,10),
		   (4,78000,N'دامن با طرح قلب',N'کاربرد مجلسی مهمانی و روزمره',9,1),
		   (4,72000,N'دامن دکمه‌دار',N'کاربرد مجلسی مهمانی و روزمره',10,4)");
        }
        
        public override void Down()
        {
        }
    }
}
