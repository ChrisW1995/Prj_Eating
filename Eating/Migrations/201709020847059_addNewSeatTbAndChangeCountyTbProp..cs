namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewSeatTbAndChangeCountyTbProp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Areas", "CountryId", "dbo.Countries");
            DropIndex("dbo.Areas", new[] { "CountryId" });
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountyName = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Areas", "CountyId", c => c.Int(nullable: true));
            CreateIndex("dbo.Areas", "CountyId");
            AddForeignKey("dbo.Areas", "CountyId", "dbo.Counties", "Id", cascadeDelete: true);
            DropColumn("dbo.Areas", "CountryId");
            DropTable("dbo.Countries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Areas", "CountryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Areas", "CountyId", "dbo.Counties");
            DropIndex("dbo.Areas", new[] { "CountyId" });
            DropColumn("dbo.Areas", "CountyId");
            DropTable("dbo.Counties");
            CreateIndex("dbo.Areas", "CountryId");
            AddForeignKey("dbo.Areas", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
