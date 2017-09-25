namespace Eating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "R_Password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "R_Password", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
