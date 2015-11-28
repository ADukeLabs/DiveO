namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Diver_Dive_Updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Divers", "HomeBase", c => c.String());
            AddColumn("dbo.Dives", "Location", c => c.String());
            AddColumn("dbo.Dives", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Divers", "Location");
            DropColumn("dbo.Dives", "Date");
            DropColumn("dbo.Dives", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dives", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Dives", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Divers", "Location", c => c.String());
            DropColumn("dbo.Dives", "DateTime");
            DropColumn("dbo.Dives", "Location");
            DropColumn("dbo.Divers", "HomeBase");
        }
    }
}
