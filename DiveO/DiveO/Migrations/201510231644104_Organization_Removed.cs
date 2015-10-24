namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization_Removed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Divers", "Organization");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Divers", "Organization", c => c.Int(nullable: false));
        }
    }
}
