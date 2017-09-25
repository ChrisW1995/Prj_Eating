namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTbReserves : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reserves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        C_Id = c.String(nullable: false, maxLength: 25),
                        SeatId = c.Int(nullable: false),
                        PeopleNum = c.Int(nullable: false),
                        Details = c.String(maxLength: 150),
                        ReserveTime = c.DateTime(nullable: false),
                        IsSomke = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.C_Id, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.SeatId, cascadeDelete: true)
                .Index(t => t.C_Id)
                .Index(t => t.SeatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserves", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.Reserves", "C_Id", "dbo.Customers");
            DropIndex("dbo.Reserves", new[] { "SeatId" });
            DropIndex("dbo.Reserves", new[] { "C_Id" });
            DropTable("dbo.Reserves");
        }
    }
}
