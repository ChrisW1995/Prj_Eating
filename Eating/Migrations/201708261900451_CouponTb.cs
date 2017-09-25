namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CouponTb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponId = c.Int(nullable: false, identity: true),
                        R_Id = c.String(nullable: false, maxLength: 25),
                        Desciption = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CouponId)
                .ForeignKey("dbo.Restaurants", t => t.R_Id, cascadeDelete: true)
                .Index(t => t.R_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coupons", "R_Id", "dbo.Restaurants");
            DropIndex("dbo.Coupons", new[] { "R_Id" });
            DropTable("dbo.Coupons");
        }
    }
}
