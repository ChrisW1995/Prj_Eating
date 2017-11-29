namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Table : DbMigration
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
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        R_Id = c.String(nullable: false, maxLength: 8),
                        FoodName = c.String(maxLength: 50),
                        ImgPath = c.String(maxLength: 125),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.R_Id, cascadeDelete: true)
                .Index(t => t.R_Id);
            
            AlterColumn("dbo.Coupons", "R_Id", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Feedbacks", "R_Id", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Restaurants", "Id", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Seats", "R_Id", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.WaitingLists", "R_Id", c => c.String(nullable: false, maxLength: 8));
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
            DropForeignKey("dbo.Menus", "R_Id", "dbo.Restaurants");
            DropIndex("dbo.WaitingLists", new[] { "R_Id" });
            DropIndex("dbo.Seats", new[] { "R_Id" });
            DropIndex("dbo.Menus", new[] { "R_Id" });
            DropIndex("dbo.Feedbacks", new[] { "R_Id" });
            DropIndex("dbo.Coupons", new[] { "R_Id" });
            DropPrimaryKey("dbo.Restaurants");
            AlterColumn("dbo.WaitingLists", "R_Id", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Seats", "R_Id", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Restaurants", "Id", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Feedbacks", "R_Id", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Coupons", "R_Id", c => c.String(nullable: false, maxLength: 32));
            DropTable("dbo.Menus");
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
