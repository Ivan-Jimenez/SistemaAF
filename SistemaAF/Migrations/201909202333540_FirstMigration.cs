namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Extranjeros",
                c => new
                    {
                        NoParte = c.String(nullable: false, maxLength: 128),
                        NoFactura = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        cantidad = c.Int(nullable: false),
                        CostoUnit = c.Int(nullable: false),
                        TipoMcia = c.String(),
                        CvePais = c.String(),
                        DescEsp = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Serie = c.String(),
                        FrMexImp = c.String(),
                        CveUm = c.String(),
                        Pedimento = c.String(),
                        Proveedor = c.String(),
                        Etiqueta = c.String(),
                        Placas = c.String(),
                        NoPacking = c.String(),
                        Comment1 = c.String(),
                        Comment2 = c.String(),
                        Comment3 = c.String(),
                        TipoImp = c.String(),
                        Test1 = c.String(),
                        Division = c.String(),
                        NoZEM = c.String(),
                        NoExt = c.String(),
                        Location = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.NoParte);
            
            CreateTable(
                "dbo.Nacionales",
                c => new
                    {
                        NoActivo = c.String(nullable: false, maxLength: 128),
                        Company = c.String(),
                        Division = c.String(),
                        SubNumber = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Name = c.String(),
                        TextLine1 = c.String(),
                        AccountingDimension4 = c.String(),
                        AccountingDimension6 = c.String(),
                        LifetimeInMonths = c.String(),
                        AcquisitionPrice = c.Int(nullable: false),
                        AcquisitionCost = c.Int(nullable: false),
                        ForecastLineart = c.String(),
                        ForecastDerogatory = c.String(),
                        Comment = c.String(),
                        StatusFinal = c.String(),
                    })
                .PrimaryKey(t => t.NoActivo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nacionales");
            DropTable("dbo.Extranjeros");
        }
    }
}
