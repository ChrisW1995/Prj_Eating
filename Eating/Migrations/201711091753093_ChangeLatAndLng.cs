namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLatAndLng : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Restaurants DROP CONSTRAINT DF__Restaurants__Lat__282DF8C2");
            AddColumn("dbo.Restaurants", "Lng", c => c.Double(nullable: false));
            AlterColumn("dbo.Restaurants", "Lat", c => c.Double(nullable: false));
            DropColumn("dbo.Restaurants", "Lon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Lon", c => c.Single(nullable: false));
            AlterColumn("dbo.Restaurants", "Lat", c => c.Single(nullable: false));
            DropColumn("dbo.Restaurants", "Lng");
        }
    }
}
