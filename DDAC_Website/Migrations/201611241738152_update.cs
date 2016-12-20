namespace DDAC_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Locations", new[] { "Cruise_id" });
            AlterColumn("dbo.Locations", "Cruise_id", c => c.Int());
            AlterColumn("dbo.Locations", "cruise_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "Cruise_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Locations", new[] { "Cruise_id" });
            AlterColumn("dbo.Locations", "cruise_id", c => c.Int());
            AlterColumn("dbo.Locations", "Cruise_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "Cruise_id");
        }
    }
}
