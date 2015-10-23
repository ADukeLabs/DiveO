namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cert_Enum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Divers", "Certification", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Divers", "Certification");
        }
    }
}
