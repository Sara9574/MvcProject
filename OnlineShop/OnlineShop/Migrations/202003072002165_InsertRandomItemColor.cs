namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertRandomItemColor : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into ItemColor
                    select id,colorid from Item
                                      
                    declare @tempItem int
                    , @temp int
                    ,@x int
                                      
                    set @x=(select count(*) from Item)*2
                      while @x > 0
                        begin
                    		select @tempItem=(SELECT TOP 1 id FROM item ORDER BY NEWID())
                    		,@temp=(SELECT TOP 1 id FROM color ORDER BY NEWID())
                    		if not exists (select 1 from itemcolor where ItemId=@tempItem and ColorId=@temp) and 
                    		(select count(distinct ic.ColorId) from ItemColor ic where ic.ItemId=@tempItem)<4
                    		insert into ItemColor values(@tempItem,@temp)
                    		set @x=@x-1
                    end");
        }
        
        public override void Down()
        {
        }
    }
}
