namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategoryValuesAreInserted : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into subCategory values
                    (1,N'کفش زنانه','women shoes',1),
                    (2,N'مانتو','manto',1),
                    (3,N'شلوار زنانه','women pants',1),
                    (4,N'دامن','skirt',1),
                    (5,N'کفش مردانه','men shoes',2),
                    (6,N'شلوار مردانه','men pants',2),
                    (7,N'ژاکت مردانه','men jacket',2),
                    (8,N'کفش بچگانه','children shoes',3),
                    (9,N'شلوار بچگانه','children pants',3),
                    (10,N'تیشر بچگانه','children tshirt',3)");
        }
        
        public override void Down()
        {
        }
    }
}
