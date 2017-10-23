namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRTbStatusFlg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "StatusFlg", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "StatusFlg");
        }
    }
}
