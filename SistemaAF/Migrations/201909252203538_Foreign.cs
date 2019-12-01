namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nacionales", "ForecastLinear", c => c.String());
            AlterColumn("dbo.Extranjeros", "Fecha", c => c.String());
            AlterColumn("dbo.Extranjeros", "cantidad", c => c.String());
            AlterColumn("dbo.Extranjeros", "CostoUnit", c => c.String());
            DropColumn("dbo.Nacionales", "ForecastLineart");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nacionales", "ForecastLineart", c => c.String());
            AlterColumn("dbo.Extranjeros", "CostoUnit", c => c.Int(nullable: false));
            AlterColumn("dbo.Extranjeros", "cantidad", c => c.Int(nullable: false));
            AlterColumn("dbo.Extranjeros", "Fecha", c => c.DateTime(nullable: false));
            DropColumn("dbo.Nacionales", "ForecastLinear");
        }
    }
}
