namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdPropC_Id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "C_Id", "dbo.Customers");
            DropForeignKey("dbo.Reserves", "C_Id", "dbo.Customers");
            DropForeignKey("dbo.WaitingLists", "C_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerCoupon", "Coupon_CId", "dbo.Customers");
            DropIndex("dbo.Feedbacks", new[] { "C_Id" });
            DropIndex("dbo.Reserves", new[] { "C_Id" });
            DropIndex("dbo.WaitingLists", new[] { "C_Id" });
            DropIndex("dbo.CustomerCoupon", new[] { "Coupon_CId" });
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.CustomerCoupon");
            AddColumn("dbo.Customers", "C_Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "C_Account", c => c.String(maxLength: 25));
            AlterColumn("dbo.Feedbacks", "C_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Reserves", "C_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.WaitingLists", "C_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerCoupon", "Coupon_CId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Customers", "C_Id");
            AddPrimaryKey("dbo.CustomerCoupon", new[] { "Coupon_Id", "Coupon_CId" });
            CreateIndex("dbo.Feedbacks", "C_Id");
            CreateIndex("dbo.Reserves", "C_Id");
            CreateIndex("dbo.WaitingLists", "C_Id");
            CreateIndex("dbo.CustomerCoupon", "Coupon_CId");
            AddForeignKey("dbo.Feedbacks", "C_Id", "dbo.Customers", "C_Id", cascadeDelete: true);
            AddForeignKey("dbo.Reserves", "C_Id", "dbo.Customers", "C_Id", cascadeDelete: true);
            AddForeignKey("dbo.WaitingLists", "C_Id", "dbo.Customers", "C_Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerCoupon", "Coupon_CId", "dbo.Customers", "C_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerCoupon", "Coupon_CId", "dbo.Customers");
            DropForeignKey("dbo.WaitingLists", "C_Id", "dbo.Customers");
            DropForeignKey("dbo.Reserves", "C_Id", "dbo.Customers");
            DropForeignKey("dbo.Feedbacks", "C_Id", "dbo.Customers");
            DropIndex("dbo.CustomerCoupon", new[] { "Coupon_CId" });
            DropIndex("dbo.WaitingLists", new[] { "C_Id" });
            DropIndex("dbo.Reserves", new[] { "C_Id" });
            DropIndex("dbo.Feedbacks", new[] { "C_Id" });
            DropPrimaryKey("dbo.CustomerCoupon");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.CustomerCoupon", "Coupon_CId", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.WaitingLists", "C_Id", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Reserves", "C_Id", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Feedbacks", "C_Id", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Customers", "C_Account", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.Customers", "C_Id");
            AddPrimaryKey("dbo.CustomerCoupon", new[] { "Coupon_Id", "Coupon_CId" });
            AddPrimaryKey("dbo.Customers", "C_Account");
            CreateIndex("dbo.CustomerCoupon", "Coupon_CId");
            CreateIndex("dbo.WaitingLists", "C_Id");
            CreateIndex("dbo.Reserves", "C_Id");
            CreateIndex("dbo.Feedbacks", "C_Id");
            AddForeignKey("dbo.CustomerCoupon", "Coupon_CId", "dbo.Customers", "C_Account", cascadeDelete: true);
            AddForeignKey("dbo.WaitingLists", "C_Id", "dbo.Customers", "C_Account", cascadeDelete: true);
            AddForeignKey("dbo.Reserves", "C_Id", "dbo.Customers", "C_Account", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "C_Id", "dbo.Customers", "C_Account", cascadeDelete: true);
        }
    }
}
