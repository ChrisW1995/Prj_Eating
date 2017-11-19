namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegIDInWaitingList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserves", "RegDeviceID", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserves", "RegDeviceID");
        }
    }
}
