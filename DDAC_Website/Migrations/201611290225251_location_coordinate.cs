namespace DDAC_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location_coordinate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Locations", new[] { "Cruise_id" });
            AddColumn("dbo.Locations", "location_coordinate", c => c.String());
            AlterColumn("dbo.Locations", "Cruise_id", c => c.Int());
            AlterColumn("dbo.Locations", "cruise_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "Cruise_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Locations", new[] { "Cruise_id" });
            AlterColumn("dbo.Locations", "cruise_id", c => c.Int());
            AlterColumn("dbo.Locations", "Cruise_id", c => c.Int(nullable: false));
            DropColumn("dbo.Locations", "location_coordinate");
            CreateIndex("dbo.Locations", "Cruise_id");
        }
    }
}
