namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRTbisCheck : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Restaurants DROP CONSTRAINT DF__Restaurants__Id__70DDC3D8");
            DropForeignKey("dbo.Seats", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.WaitingLists", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Feedbacks", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Coupons", "R_Id", "dbo.Restaurants");
            DropIndex("dbo.Coupons", new[] { "R_Id" });
            DropIndex("dbo.Feedbacks", new[] { "R_Id" });
            DropIndex("dbo.Seats", new[] { "R_Id" });
            DropIndex("dbo.WaitingLists", new[] { "R_Id" });
            DropPrimaryKey("dbo.Restaurants");
            AddColumn("dbo.Restaurants", "isCheck", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Restaurants", "Id", c => c.String(nullable: false, maxLength: 32));
            AddPrimaryKey("dbo.Restaurants", "Id");
            AlterColumn("dbo.Coupons", "R_Id", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Feedbacks", "R_Id", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Seats", "R_Id", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.WaitingLists", "R_Id", c => c.String(nullable: false, maxLength: 32));
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
            AlterColumn("dbo.WaitingLists", "R_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Seats", "R_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Restaurants", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Feedbacks", "R_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Coupons", "R_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.Restaurants", "isCheck");
            AddPrimaryKey("dbo.Restaurants", "Id");
            CreateIndex("dbo.WaitingLists", "R_Id");
            CreateIndex("dbo.Seats", "R_Id");
            CreateIndex("dbo.Feedbacks", "R_Id");
            CreateIndex("dbo.Coupons", "R_Id");
            AddForeignKey("dbo.Coupons", "R_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "R_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WaitingLists", "R_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Seats", "R_Id", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
    }
}
