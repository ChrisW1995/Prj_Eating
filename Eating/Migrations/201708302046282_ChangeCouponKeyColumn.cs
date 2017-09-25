namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCouponKeyColumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Coupons");
            DropColumn("dbo.Coupons", "CouponId");
            AddColumn("dbo.Coupons", "CouponId", c => c.String(nullable: false, maxLength: 100));
            //AlterColumn("dbo.Coupons", "CouponId", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.Coupons", "CouponId");
            CreateIndex("dbo.Coupons", "CouponId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Coupons", new[] { "CouponId" });
            DropPrimaryKey("dbo.Coupons");
            DropColumn("dbo.Coupons", "CouponId");
            AddColumn("dbo.Coupons", "CouponId", c => c.Guid(nullable: false));
            // AlterColumn("dbo.Coupons", "CouponId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Coupons", "CouponId");
        }
    }
}
