namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sep301 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nacionales", "AcoumatedDrepreciationLinear", c => c.String());
            AddColumn("dbo.Nacionales", "Location", c => c.String());
            DropColumn("dbo.Extranjeros", "NoFactura");
            DropColumn("dbo.Extranjeros", "Cuadrante");
            DropColumn("dbo.Nacionales", "AccoumatedDrepreciationLinear");
            DropColumn("dbo.Nacionales", "Cuadrante");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nacionales", "Cuadrante", c => c.String());
            AddColumn("dbo.Nacionales", "AccoumatedDrepreciationLinear", c => c.String());
            AddColumn("dbo.Extranjeros", "Cuadrante", c => c.String());
            AddColumn("dbo.Extranjeros", "NoFactura", c => c.String());
            DropColumn("dbo.Nacionales", "Location");
            DropColumn("dbo.Nacionales", "AcoumatedDrepreciationLinear");
        }
    }
}
