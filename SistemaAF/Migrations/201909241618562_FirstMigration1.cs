namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nacionales", "SubNumber", c => c.String());
            AlterColumn("dbo.Nacionales", "Status", c => c.String());
            AlterColumn("dbo.Nacionales", "AcquisitionPrice", c => c.String());
            AlterColumn("dbo.Nacionales", "AcquisitionCost", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nacionales", "AcquisitionCost", c => c.Int(nullable: false));
            AlterColumn("dbo.Nacionales", "AcquisitionPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Nacionales", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Nacionales", "SubNumber", c => c.Int(nullable: false));
        }
    }
}
