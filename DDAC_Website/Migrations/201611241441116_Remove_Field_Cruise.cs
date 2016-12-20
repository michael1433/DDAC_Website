namespace DDAC_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Field_Cruise : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cruises", "unique_string_keyword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cruises", "unique_string_keyword", c => c.String());
        }
    }
}
