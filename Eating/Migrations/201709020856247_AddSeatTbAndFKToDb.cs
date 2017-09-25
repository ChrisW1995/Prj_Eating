namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeatTbAndFKToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        R_Id = c.String(nullable: false, maxLength: 25),
                        SeatName = c.String(),
                        SeatCapacity = c.Int(nullable: false),
                        SeatDetail = c.String(maxLength: 100),
                        SeatSmoke = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.Restaurants", t => t.R_Id, cascadeDelete: true)
                .Index(t => t.R_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "R_Id", "dbo.Restaurants");
            DropIndex("dbo.Seats", new[] { "R_Id" });
            DropTable("dbo.Seats");
        }
    }
}
