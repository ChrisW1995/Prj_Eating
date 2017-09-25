namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeatXANDYLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "location_X", c => c.Single(nullable: false));
            AddColumn("dbo.Seats", "location_Y", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seats", "location_Y");
            DropColumn("dbo.Seats", "location_X");
        }
    }
}
