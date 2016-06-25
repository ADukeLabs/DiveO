namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapPoint_AddedTo_Dive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dives", "MapPoint_Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Dives", "MapPoint_Longitude", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dives", "MapPoint_Longitude");
            DropColumn("dbo.Dives", "MapPoint_Latitude");
        }
    }
}
