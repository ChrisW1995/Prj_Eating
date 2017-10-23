namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRTSProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "ReserveTimeSpan", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "ReserveTimeSpan");
        }
    }
}
