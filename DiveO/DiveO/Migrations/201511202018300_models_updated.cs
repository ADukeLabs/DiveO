namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class models_updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dives", "Diver_Id", "dbo.Divers");
            DropIndex("dbo.Dives", new[] { "Diver_Id" });
            RenameColumn(table: "dbo.Dives", name: "Diver_Id", newName: "DiverId");
            AlterColumn("dbo.Dives", "DiverId", c => c.Int(nullable: false));
            CreateIndex("dbo.Dives", "DiverId");
            AddForeignKey("dbo.Dives", "DiverId", "dbo.Divers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dives", "DiverId", "dbo.Divers");
            DropIndex("dbo.Dives", new[] { "DiverId" });
            AlterColumn("dbo.Dives", "DiverId", c => c.Int());
            RenameColumn(table: "dbo.Dives", name: "DiverId", newName: "Diver_Id");
            CreateIndex("dbo.Dives", "Diver_Id");
            AddForeignKey("dbo.Dives", "Diver_Id", "dbo.Divers", "Id");
        }
    }
}
