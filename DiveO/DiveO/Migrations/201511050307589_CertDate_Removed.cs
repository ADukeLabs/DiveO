namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CertDate_Removed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Divers", "CertDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Divers", "CertDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
