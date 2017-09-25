namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewWaitingListTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WaitingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentNo = c.Int(nullable: false),
                        Detail = c.String(maxLength: 200),
                        AddTime = c.DateTime(nullable: false),
                        C_Id = c.String(nullable: false, maxLength: 25),
                        R_Id = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.C_Id, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.R_Id, cascadeDelete: true)
                .Index(t => t.C_Id)
                .Index(t => t.R_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        C_Account = c.String(nullable: false, maxLength: 25),
                        C_Password = c.String(nullable: false, maxLength: 50),
                        C_Name = c.String(nullable: false, maxLength: 50),
                        C_PhoneNum = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        SignUpTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.C_Account);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WaitingLists", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.WaitingLists", "C_Id", "dbo.Customers");
            DropIndex("dbo.WaitingLists", new[] { "R_Id" });
            DropIndex("dbo.WaitingLists", new[] { "C_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.WaitingLists");
        }
    }
}
