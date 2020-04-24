namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altercatnames : DbMigration
    {
        public override void Up()
        {
            Sql(@"update SubCategory
                    set Title=N'کفش' where id=1
                    update SubCategory
                    set Title=N'شلوار' where id=3
                    update SubCategory
                    set Title=N'کفش' where id=5
                    update SubCategory
                    set Title=N'کفش' where id=6
                    update SubCategory
                    set Title=N'ژاکت' where id=7
                    update SubCategory
                    set Title=N'کفش' where id=8
                    update SubCategory
                    set Title=N'شلوار' where id=9
                    update SubCategory
                    set Title=N'تیشرت' where id=10");
        }
        
        public override void Down()
        {
        }
    }
}
