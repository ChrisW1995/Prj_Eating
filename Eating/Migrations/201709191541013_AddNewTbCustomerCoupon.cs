namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTbCustomerCoupon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerCoupon",
                c => new
                    {
                        Coupon_Id = c.String(nullable: false, maxLength: 100),
                        Coupon_CId = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => new { t.Coupon_Id, t.Coupon_CId })
                .ForeignKey("dbo.Coupons", t => t.Coupon_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Coupon_CId, cascadeDelete: true)
                .Index(t => t.Coupon_Id)
                .Index(t => t.Coupon_CId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerCoupon", "Coupon_CId", "dbo.Customers");
            DropForeignKey("dbo.CustomerCoupon", "Coupon_Id", "dbo.Coupons");
            DropIndex("dbo.CustomerCoupon", new[] { "Coupon_CId" });
            DropIndex("dbo.CustomerCoupon", new[] { "Coupon_Id" });
            DropTable("dbo.CustomerCoupon");
        }
    }
}
