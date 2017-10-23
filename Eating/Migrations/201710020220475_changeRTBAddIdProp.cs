namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeRTBAddIdProp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.WaitingLists", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Feedbacks", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Coupons", "R_Id", "dbo.Restaurants");
            DropIndex("dbo.Coupons", new[] { "R_Id" });
            DropIndex("dbo.Feedbacks", new[] { "R_Id" });
            DropIndex("dbo.Seats", new[] { "R_Id" });
            DropIndex("dbo.WaitingLists", new[] { "R_Id" });
            DropPrimaryKey("dbo.Restaurants");
            AddColumn("dbo.Restaurants", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Coupons", "R_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Feedbacks", "R_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Restaurants", "R_Account", c => c.String(maxLength: 25));
            AlterColumn("dbo.Seats", "R_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.WaitingLists", "R_Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Restaurants", "Id");
            CreateIndex("dbo.Coupons", "R_Id");
            CreateIndex("dbo.Feedbacks", "R_Id");
            CreateIndex("dbo.Seats", "R_Id");
            CreateIndex("dbo.WaitingLists", "R_Id");
            AddForeignKey("dbo.Seats", "R_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WaitingLists", "R_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "R_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Coupons", "R_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coupons", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Feedbacks", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.WaitingLists", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Seats", "R_Id", "dbo.Restaurants");
            DropIndex("dbo.WaitingLists", new[] { "R_Id" });
            DropIndex("dbo.Seats", new[] { "R_Id" });
            DropIndex("dbo.Feedbacks", new[] { "R_Id" });
            DropIndex("dbo.Coupons", new[] { "R_Id" });
            DropPrimaryKey("dbo.Restaurants");
            AlterColumn("dbo.WaitingLists", "R_Id", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Seats", "R_Id", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Restaurants", "R_Account", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Feedbacks", "R_Id", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Coupons", "R_Id", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.Restaurants", "Id");
            AddPrimaryKey("dbo.Restaurants", "R_Account");
            CreateIndex("dbo.WaitingLists", "R_Id");
            CreateIndex("dbo.Seats", "R_Id");
            CreateIndex("dbo.Feedbacks", "R_Id");
            CreateIndex("dbo.Coupons", "R_Id");
            AddForeignKey("dbo.Coupons", "R_Id", "dbo.Restaurants", "R_Account", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "R_Id", "dbo.Restaurants", "R_Account", cascadeDelete: true);
            AddForeignKey("dbo.WaitingLists", "R_Id", "dbo.Restaurants", "R_Account", cascadeDelete: true);
            AddForeignKey("dbo.Seats", "R_Id", "dbo.Restaurants", "R_Account", cascadeDelete: true);
        }
    }
}
