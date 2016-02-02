namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo_Collection_Changed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiveId = c.Int(nullable: false),
                        PhotoBytes = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dives", t => t.DiveId, cascadeDelete: true)
                .Index(t => t.DiveId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "DiveId", "dbo.Dives");
            DropIndex("dbo.Photos", new[] { "DiveId" });
            DropTable("dbo.Photos");
        }
    }
}
