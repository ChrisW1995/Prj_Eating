namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adm_Account = c.String(maxLength: 25),
                        Adm_Password = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 5),
                        CountyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaId)
                .ForeignKey("dbo.Counties", t => t.CountyId, cascadeDelete: true)
                .Index(t => t.CountyId);
            
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountyName = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponId = c.String(nullable: false, maxLength: 100),
                        R_Id = c.String(nullable: false, maxLength: 8),
                        Title = c.String(nullable: false, maxLength: 25),
                        Desciption = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CouponId)
                .ForeignKey("dbo.Restaurants", t => t.R_Id, cascadeDelete: true)
                .Index(t => t.CouponId)
                .Index(t => t.R_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        C_Id = c.Int(nullable: false, identity: true),
                        C_Account = c.String(maxLength: 25),
                        C_Password = c.String(nullable: false, maxLength: 50),
                        C_Name = c.String(nullable: false, maxLength: 50),
                        C_PhoneNum = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        SignUpTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.C_Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        R_Id = c.String(nullable: false, maxLength: 8),
                        C_Id = c.Int(nullable: false),
                        Rating = c.Byte(nullable: false),
                        Comment = c.String(maxLength: 200),
                        CommentTime = c.DateTime(nullable: false),
                        Reply = c.String(maxLength: 200),
                        ReplyTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.C_Id, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.R_Id, cascadeDelete: true)
                .Index(t => t.R_Id)
                .Index(t => t.C_Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 8),
                        R_Account = c.String(maxLength: 25),
                        R_Password = c.String(nullable: false, maxLength: 50),
                        R_Name = c.String(nullable: false, maxLength: 50),
                        R_PhoneNum = c.String(nullable: false, maxLength: 15),
                        R_County = c.String(nullable: false, maxLength: 5),
                        R_Area = c.String(nullable: false, maxLength: 5),
                        R_DetailAddress = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        AuthCode = c.String(maxLength: 20),
                        StartTime = c.Time(nullable: false, precision: 7),
                        CloseTime = c.Time(nullable: false, precision: 7),
                        SignUpTime = c.DateTime(nullable: false),
                        StatusFlg = c.Boolean(nullable: false),
                        isCheck = c.Boolean(nullable: false),
                        ReserveTimeSpan = c.Int(nullable: false),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        ImagePath = c.String(maxLength: 50),
                        WaitListSwitch = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        R_Id = c.String(nullable: false, maxLength: 8),
                        SeatName = c.String(),
                        SeatCapacity = c.Int(nullable: false),
                        SeatDetail = c.String(maxLength: 100),
                        SeatSmoke = c.Boolean(nullable: false),
                        location_X = c.Single(nullable: false),
                        location_Y = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.R_Id, cascadeDelete: true)
                .Index(t => t.R_Id);
            
            CreateTable(
                "dbo.SetReservationDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatId = c.Int(nullable: false),
                        ReservationTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: true)
                .Index(t => t.SeatId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        C_Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 25),
                        PhoneNum = c.String(nullable: false, maxLength: 15),
                        ReservationTimeId = c.Int(nullable: false),
                        PeopleNum = c.Int(nullable: false),
                        Details = c.String(maxLength: 150),
                        RegDeviceID = c.String(maxLength: 200),
                        AddTime = c.DateTime(nullable: false),
                        IsSomke = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.C_Id, cascadeDelete: true)
                .ForeignKey("dbo.SetReservationDetails", t => t.ReservationTimeId, cascadeDelete: true)
                .Index(t => t.C_Id)
                .Index(t => t.ReservationTimeId);
            
            CreateTable(
                "dbo.WaitingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentNo = c.Int(nullable: false),
                        PeopleNum = c.Int(nullable: false),
                        Detail = c.String(maxLength: 200),
                        AddTime = c.DateTime(nullable: false),
                        C_Id = c.Int(nullable: false),
                        R_Id = c.String(nullable: false, maxLength: 8),
                        RegDeviceID = c.String(maxLength: 200),
                        CheckStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.C_Id, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.R_Id, cascadeDelete: true)
                .Index(t => t.C_Id)
                .Index(t => t.R_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.CustomerCoupon",
                c => new
                    {
                        Coupon_Id = c.String(nullable: false, maxLength: 100),
                        Coupon_CId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Coupon_Id, t.Coupon_CId })
                .ForeignKey("dbo.Coupons", t => t.Coupon_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Coupon_CId, cascadeDelete: true)
                .Index(t => t.Coupon_Id)
                .Index(t => t.Coupon_CId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Coupons", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.CustomerCoupon", "Coupon_CId", "dbo.Customers");
            DropForeignKey("dbo.CustomerCoupon", "Coupon_Id", "dbo.Coupons");
            DropForeignKey("dbo.Feedbacks", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.WaitingLists", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.WaitingLists", "C_Id", "dbo.Customers");
            DropForeignKey("dbo.SetReservationDetails", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.Reservations", "ReservationTimeId", "dbo.SetReservationDetails");
            DropForeignKey("dbo.Reservations", "C_Id", "dbo.Customers");
            DropForeignKey("dbo.Seats", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Feedbacks", "C_Id", "dbo.Customers");
            DropForeignKey("dbo.Areas", "CountyId", "dbo.Counties");
            DropIndex("dbo.CustomerCoupon", new[] { "Coupon_CId" });
            DropIndex("dbo.CustomerCoupon", new[] { "Coupon_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.WaitingLists", new[] { "R_Id" });
            DropIndex("dbo.WaitingLists", new[] { "C_Id" });
            DropIndex("dbo.Reservations", new[] { "ReservationTimeId" });
            DropIndex("dbo.Reservations", new[] { "C_Id" });
            DropIndex("dbo.SetReservationDetails", new[] { "SeatId" });
            DropIndex("dbo.Seats", new[] { "R_Id" });
            DropIndex("dbo.Feedbacks", new[] { "C_Id" });
            DropIndex("dbo.Feedbacks", new[] { "R_Id" });
            DropIndex("dbo.Coupons", new[] { "R_Id" });
            DropIndex("dbo.Coupons", new[] { "CouponId" });
            DropIndex("dbo.Areas", new[] { "CountyId" });
            DropTable("dbo.CustomerCoupon");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.WaitingLists");
            DropTable("dbo.Reservations");
            DropTable("dbo.SetReservationDetails");
            DropTable("dbo.Seats");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Customers");
            DropTable("dbo.Coupons");
            DropTable("dbo.Counties");
            DropTable("dbo.Areas");
            DropTable("dbo.Admins");
        }
    }
}
