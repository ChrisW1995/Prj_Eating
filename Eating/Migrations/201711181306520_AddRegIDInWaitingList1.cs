namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegIDInWaitingList1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WaitingLists", "RegDeviceID", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WaitingLists", "RegDeviceID");
        }
    }
}
