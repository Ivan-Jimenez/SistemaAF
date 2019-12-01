namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sep30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Extranjeros", "Cuadrante", c => c.String());
            AddColumn("dbo.Nacionales", "AcquisitionDate", c => c.String());
            AddColumn("dbo.Nacionales", "AccountingDimension2", c => c.String());
            AddColumn("dbo.Nacionales", "PhysicalInventoryNo", c => c.String());
            AddColumn("dbo.Nacionales", "AccoumatedDrepreciationLinear", c => c.String());
            AddColumn("dbo.Nacionales", "YearToDateDepreciationLinear", c => c.String());
            AddColumn("dbo.Nacionales", "Cuadrante", c => c.String());
            DropColumn("dbo.Nacionales", "AccountingDimension4");
            DropColumn("dbo.Nacionales", "ForecastDerogatory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nacionales", "ForecastDerogatory", c => c.String());
            AddColumn("dbo.Nacionales", "AccountingDimension4", c => c.String());
            DropColumn("dbo.Nacionales", "Cuadrante");
            DropColumn("dbo.Nacionales", "YearToDateDepreciationLinear");
            DropColumn("dbo.Nacionales", "AccoumatedDrepreciationLinear");
            DropColumn("dbo.Nacionales", "PhysicalInventoryNo");
            DropColumn("dbo.Nacionales", "AccountingDimension2");
            DropColumn("dbo.Nacionales", "AcquisitionDate");
            DropColumn("dbo.Extranjeros", "Cuadrante");
        }
    }
}
