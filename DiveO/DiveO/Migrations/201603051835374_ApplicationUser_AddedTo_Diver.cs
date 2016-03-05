namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUser_AddedTo_Diver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Divers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Divers", "ApplicationUser_Id");
            AddForeignKey("dbo.Divers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Divers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Divers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Divers", "ApplicationUser_Id");
        }
    }
}
