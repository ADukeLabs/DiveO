namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapPoint_ChangedTo_FloatProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dives", "Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Dives", "Longitude", c => c.Single(nullable: false));
            DropColumn("dbo.Dives", "MapPoint_Latitude");
            DropColumn("dbo.Dives", "MapPoint_Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dives", "MapPoint_Longitude", c => c.Single(nullable: false));
            AddColumn("dbo.Dives", "MapPoint_Latitude", c => c.Single(nullable: false));
            DropColumn("dbo.Dives", "Longitude");
            DropColumn("dbo.Dives", "Latitude");
        }
    }
}
