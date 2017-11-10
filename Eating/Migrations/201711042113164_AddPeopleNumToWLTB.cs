namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPeopleNumToWLTB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WaitingLists", "PeopleNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WaitingLists", "PeopleNum");
        }
    }
}
