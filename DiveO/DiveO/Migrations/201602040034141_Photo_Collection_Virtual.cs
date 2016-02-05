namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo_Collection_Virtual : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Photos", "DiveId");
            AddForeignKey("dbo.Photos", "DiveId", "dbo.Dives", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "DiveId", "dbo.Dives");
            DropIndex("dbo.Photos", new[] { "DiveId" });
        }
    }
}
