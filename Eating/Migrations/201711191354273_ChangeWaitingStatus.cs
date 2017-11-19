namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWaitingStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "waitingStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "waitingStatus");
        }
    }
}
