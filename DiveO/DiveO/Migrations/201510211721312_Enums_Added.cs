namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enums_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Divers", "Organization", c => c.Int(nullable: false));
            DropColumn("dbo.Divers", "Certification");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Divers", "Certification", c => c.String());
            DropColumn("dbo.Divers", "Organization");
        }
    }
}
