namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo_Collection_Removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "DiveId", "dbo.Dives");
            DropIndex("dbo.Photos", new[] { "DiveId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Photos", "DiveId");
            AddForeignKey("dbo.Photos", "DiveId", "dbo.Dives", "Id", cascadeDelete: true);
        }
    }
}
