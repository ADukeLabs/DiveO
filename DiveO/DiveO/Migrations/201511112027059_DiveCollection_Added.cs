namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiveCollection_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dives", "Diver_Id", c => c.Int());
            AlterColumn("dbo.Dives", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Dives", "Depth", c => c.String());
            CreateIndex("dbo.Dives", "Diver_Id");
            AddForeignKey("dbo.Dives", "Diver_Id", "dbo.Divers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dives", "Diver_Id", "dbo.Divers");
            DropIndex("dbo.Dives", new[] { "Diver_Id" });
            AlterColumn("dbo.Dives", "Depth", c => c.Double(nullable: false));
            AlterColumn("dbo.Dives", "Time", c => c.String());
            DropColumn("dbo.Dives", "Diver_Id");
        }
    }
}
