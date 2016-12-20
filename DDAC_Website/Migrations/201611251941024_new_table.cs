namespace DDAC_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Locations", new[] { "Cruise_id" });
            CreateTable(
                "dbo.States",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        stateRoomType = c.String(),
                        stateRoomPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AlterColumn("dbo.Locations", "Cruise_id", c => c.Int());
            AlterColumn("dbo.Locations", "cruise_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "Cruise_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Locations", new[] { "Cruise_id" });
            AlterColumn("dbo.Locations", "cruise_id", c => c.Int());
            AlterColumn("dbo.Locations", "Cruise_id", c => c.Int(nullable: false));
            DropTable("dbo.States");
            CreateIndex("dbo.Locations", "Cruise_id");
        }
    }
}
