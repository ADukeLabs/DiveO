namespace DiveO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CertDate_ChangedTo_datetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Divers", "CertDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Divers", "CertDate", c => c.DateTime(nullable: false));
        }
    }
}
