namespace DDAC_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_New_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cruises",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cruise_start_date = c.DateTime(nullable: false),
                        cruise_name = c.String(nullable: false),
                        cruise_end_date = c.DateTime(nullable: false),
                        cruise_duration = c.Int(nullable: false),
                        Continent = c.String(nullable: false, maxLength: 40),
                        unique_string_keyword = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CruiseLocations",
                c => new
                    {
                        Cruise_id = c.Int(nullable: false),
                        Location_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cruise_id, t.Location_Id })
                .ForeignKey("dbo.Cruises", t => t.Cruise_id, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .Index(t => t.Cruise_id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CruiseLocations", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.CruiseLocations", "Cruise_id", "dbo.Cruises");
            DropIndex("dbo.CruiseLocations", new[] { "Location_Id" });
            DropIndex("dbo.CruiseLocations", new[] { "Cruise_id" });
            DropTable("dbo.CruiseLocations");
            DropTable("dbo.Cruises");
            DropTable("dbo.Locations");
        }
    }
}
