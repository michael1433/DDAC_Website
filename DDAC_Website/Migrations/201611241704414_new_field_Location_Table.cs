namespace DDAC_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_field_Location_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CruiseLocations", "Cruise_id", "dbo.Cruises");
            DropForeignKey("dbo.CruiseLocations", "Location_Id", "dbo.Locations");
            DropIndex("dbo.CruiseLocations", new[] { "Cruise_id" });
            DropIndex("dbo.CruiseLocations", new[] { "Location_Id" });
            AddColumn("dbo.Locations", "travel_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Locations", "cruise_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "Cruise_id");
            AddForeignKey("dbo.Locations", "Cruise_id", "dbo.Cruises", "id");
            DropTable("dbo.CruiseLocations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CruiseLocations",
                c => new
                    {
                        Cruise_id = c.Int(nullable: false),
                        Location_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cruise_id, t.Location_Id });
            
            DropForeignKey("dbo.Locations", "Cruise_id", "dbo.Cruises");
            DropIndex("dbo.Locations", new[] { "Cruise_id" });
            DropColumn("dbo.Locations", "cruise_id");
            DropColumn("dbo.Locations", "travel_Date");
            CreateIndex("dbo.CruiseLocations", "Location_Id");
            CreateIndex("dbo.CruiseLocations", "Cruise_id");
            AddForeignKey("dbo.CruiseLocations", "Location_Id", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CruiseLocations", "Cruise_id", "dbo.Cruises", "id", cascadeDelete: true);
        }
    }
}
