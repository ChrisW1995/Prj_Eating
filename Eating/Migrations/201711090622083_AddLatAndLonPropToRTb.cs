namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLatAndLonPropToRTb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Lat", c => c.Single(nullable: false));
            AddColumn("dbo.Restaurants", "Lon", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Lon");
            DropColumn("dbo.Restaurants", "Lat");
        }
    }
}
