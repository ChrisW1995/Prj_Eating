namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCouponTbTitleColumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Coupons");
            AddColumn("dbo.Coupons", "Title", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Coupons", "CouponId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Coupons", "CouponId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Coupons");
            AlterColumn("dbo.Coupons", "CouponId", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Coupons", "Title");
            AddPrimaryKey("dbo.Coupons", "CouponId");
        }
    }
}
