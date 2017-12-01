namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_VerifyCode_In_Customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "VerifyCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "VerifyCode");
        }
    }
}
