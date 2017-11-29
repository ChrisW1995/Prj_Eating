namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_FK_In_SetTimeTB : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SetReservationDetails", "R_id");
            AddForeignKey("dbo.SetReservationDetails", "R_id", "dbo.Restaurants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SetReservationDetails", "R_id", "dbo.Restaurants");
            DropIndex("dbo.SetReservationDetails", new[] { "R_id" });
        }
    }
}
