namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dive_ForeignKey_Changed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dives", "DiverId", "dbo.Divers");
            DropIndex("dbo.Dives", new[] { "DiverId" });
            RenameColumn(table: "dbo.Dives", name: "DiverId", newName: "Diver_Id");
            AlterColumn("dbo.Dives", "Diver_Id", c => c.Int());
            CreateIndex("dbo.Dives", "Diver_Id");
            AddForeignKey("dbo.Dives", "Diver_Id", "dbo.Divers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dives", "Diver_Id", "dbo.Divers");
            DropIndex("dbo.Dives", new[] { "Diver_Id" });
            AlterColumn("dbo.Dives", "Diver_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Dives", name: "Diver_Id", newName: "DiverId");
            CreateIndex("dbo.Dives", "DiverId");
            AddForeignKey("dbo.Dives", "DiverId", "dbo.Divers", "Id", cascadeDelete: true);
        }
    }
}
