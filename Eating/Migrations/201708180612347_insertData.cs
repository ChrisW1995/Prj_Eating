namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertData : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Countries values('臺北市')");
            Sql("insert into Countries values('新北市')");
            Sql("insert into Countries values('桃園市')");
            Sql("insert into Countries values('臺中市')");
            Sql("insert into Countries values('臺南市')");
            Sql("insert into Countries values('高雄市')");
            Sql("insert into Countries values('基隆市')");
            Sql("insert into Countries values('新竹市')");
            Sql("insert into Countries values('新竹縣')");
            Sql("insert into Countries values('苗栗縣')");
            Sql("insert into Countries values('嘉義市')");
            Sql("insert into Countries values('彰化縣')");
            Sql("insert into Countries values('南投縣')");
            Sql("insert into Countries values('雲林縣')");
            Sql("insert into Countries values('嘉義縣')");
            Sql("insert into Countries values('屏東縣')");
            Sql("insert into Countries values('宜蘭縣')");
            Sql("insert into Countries values('花蓮縣')");
            Sql("insert into Countries values('臺東縣')");
            Sql("insert into Countries values('澎湖縣')");
            Sql("insert into Countries values('金門縣')");
            Sql("insert into Countries values('連江縣')");
        }
        
        public override void Down()
        {
        }
    }
}
