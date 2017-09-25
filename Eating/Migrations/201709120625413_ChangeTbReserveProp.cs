namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTbReserveProp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reserves", "PeopleNum", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reserves", "PeopleNum", c => c.Int(nullable: false));
        }
    }
}
