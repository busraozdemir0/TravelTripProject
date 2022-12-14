namespace TravelTripProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_file : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogImage_yol", c => c.String());
            DropColumn("dbo.Blogs", "BlogImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogImage", c => c.String());
            DropColumn("dbo.Blogs", "BlogImage_yol");
        }
    }
}
