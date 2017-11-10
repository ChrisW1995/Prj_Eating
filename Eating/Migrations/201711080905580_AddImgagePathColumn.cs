namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImgagePathColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "ImagePath");
        }
    }
}
