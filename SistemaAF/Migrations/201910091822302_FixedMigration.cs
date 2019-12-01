namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Extranjeros", "NoFactura", c => c.String());
            DropColumn("dbo.Extranjeros", "CvePais");
            DropColumn("dbo.Extranjeros", "FrMexImp");
            DropColumn("dbo.Extranjeros", "CveUm");
            DropColumn("dbo.Extranjeros", "Etiqueta");
            DropColumn("dbo.Extranjeros", "Comment2");
            DropColumn("dbo.Extranjeros", "Comment3");
            DropColumn("dbo.Extranjeros", "TipoImp");
            DropColumn("dbo.Nacionales", "Company");
            DropColumn("dbo.Nacionales", "SubNumber");
            DropColumn("dbo.Nacionales", "AcquisitionPrice");
            DropColumn("dbo.Nacionales", "StatusFinal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nacionales", "StatusFinal", c => c.String());
            AddColumn("dbo.Nacionales", "AcquisitionPrice", c => c.String());
            AddColumn("dbo.Nacionales", "SubNumber", c => c.String());
            AddColumn("dbo.Nacionales", "Company", c => c.String());
            AddColumn("dbo.Extranjeros", "TipoImp", c => c.String());
            AddColumn("dbo.Extranjeros", "Comment3", c => c.String());
            AddColumn("dbo.Extranjeros", "Comment2", c => c.String());
            AddColumn("dbo.Extranjeros", "Etiqueta", c => c.String());
            AddColumn("dbo.Extranjeros", "CveUm", c => c.String());
            AddColumn("dbo.Extranjeros", "FrMexImp", c => c.String());
            AddColumn("dbo.Extranjeros", "CvePais", c => c.String());
            DropColumn("dbo.Extranjeros", "NoFactura");
        }
    }
}
