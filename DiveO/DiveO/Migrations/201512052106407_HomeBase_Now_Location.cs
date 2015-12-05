namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomeBase_Now_Location : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Divers", "Location", c => c.String());
            DropColumn("dbo.Divers", "HomeBase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Divers", "HomeBase", c => c.String());
            DropColumn("dbo.Divers", "Location");
        }
    }
}
