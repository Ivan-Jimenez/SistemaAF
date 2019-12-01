namespace SistemaAF.Migrations
{
    using SistemaAF.Areas.ActivosFijos.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SistemaAF.Areas.ActivosFijos.Models.ActivosFijosEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SistemaAF.Areas.ActivosFijos.Models.ActivosFijosEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var nacionalDocument = new List<NacionalDocument>
            {
                new NacionalDocument
                {
                    NoAsset = "asset01",
                    DocumentType = "FACTURA",
                    DocumentName = "TestFactura",
                },
                new NacionalDocument
                {
                    NoAsset = "asset01",
                    DocumentType = "PO",
                    DocumentName = "TestFactura",
                },
                new NacionalDocument
                {
                    NoAsset = "asset01",
                    DocumentType = "POLIZA",
                    DocumentName = "TestPoliza",
                },
                new NacionalDocument
                {
                    NoAsset = "asset01",
                    DocumentType = "PO",
                    DocumentName = "TestPO2",
                },
                new NacionalDocument
                {
                    NoAsset = "asset01",
                    DocumentType = "SCREENSHOOT",
                    DocumentName = "ScreenshootTest",
                },
            };

            var db = new ActivosFijosEntities();
            foreach(var item in nacionalDocument)
            {
                db.Entry(item);
            }
        }
    }
}
