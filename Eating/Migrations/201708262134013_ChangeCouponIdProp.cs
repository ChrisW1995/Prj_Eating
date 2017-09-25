namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCouponIdProp : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Coupons");
            DropColumn("dbo.Coupons", "CouponId");
            AddColumn("dbo.Coupons", "CouponId", c => c.Guid(nullable: false, identity: true));

          //  AlterColumn("dbo.Coupons", "CouponId", c => c.String(nullable: false, maxLength: 30));
            AddPrimaryKey("dbo.Coupons", "CouponId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Coupons");
            DropColumn("dbo.Coupons", "CouponId");
            AddColumn("dbo.Coupons", "CouponId", c => c.Int(nullable: false, identity: true));

            //   AlterColumn("dbo.Coupons", "CouponId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Coupons", "CouponId");
        }
    }
}
