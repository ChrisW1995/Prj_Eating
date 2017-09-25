namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTbPropRegistOpenAndCloseTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "StartTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Restaurants", "CloseTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "CloseTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Restaurants", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
