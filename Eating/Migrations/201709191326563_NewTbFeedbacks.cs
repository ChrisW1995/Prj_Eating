namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTbFeedbacks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        R_Id = c.String(nullable: false, maxLength: 25),
                        C_Id = c.String(nullable: false, maxLength: 25),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "R_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Feedbacks", "C_Id", "dbo.Customers");
            DropIndex("dbo.Feedbacks", new[] { "C_Id" });
            DropIndex("dbo.Feedbacks", new[] { "R_Id" });
            DropTable("dbo.Feedbacks");
        }
    }
}
