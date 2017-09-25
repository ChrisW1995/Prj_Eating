namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRTbPropAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "R_County", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.Restaurants", "R_Area", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.Restaurants", "R_DetailAddress", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Restaurants", "R_Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "R_Address", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Restaurants", "R_DetailAddress");
            DropColumn("dbo.Restaurants", "R_Area");
            DropColumn("dbo.Restaurants", "R_County");
        }
    }
}
