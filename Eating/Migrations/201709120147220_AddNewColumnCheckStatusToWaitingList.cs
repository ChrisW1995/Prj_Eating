namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumnCheckStatusToWaitingList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WaitingLists", "CheckStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WaitingLists", "CheckStatus");
        }
    }
}
