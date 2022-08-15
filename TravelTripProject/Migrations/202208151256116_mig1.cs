namespace TravelTripProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AdresBlogs");
        }
        
        public override void Down()
        {
            DropTable("dbo.AdresBlogs");
            
        }
    }
}
