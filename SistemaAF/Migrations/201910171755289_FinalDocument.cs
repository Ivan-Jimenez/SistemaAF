namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalDocument : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtranjeroDocuments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DocumentType = c.String(nullable: false),
                        DocumentName = c.String(nullable: false),
                        NoAsset = c.String(nullable: false),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NacionalDocuments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DocumentType = c.String(nullable: false),
                        DocumentName = c.String(nullable: false),
                        NoAsset = c.String(nullable: false),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Documents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DocumentType = c.String(nullable: false),
                        DocumentName = c.String(nullable: false),
                        NoAsset = c.String(nullable: false),
                        AssetType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.NacionalDocuments");
            DropTable("dbo.ExtranjeroDocuments");
        }
    }
}
