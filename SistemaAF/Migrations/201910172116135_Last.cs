namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Last : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ExtranjeroDocuments", "Path");
            DropColumn("dbo.NacionalDocuments", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NacionalDocuments", "Path", c => c.String(nullable: false));
            AddColumn("dbo.ExtranjeroDocuments", "Path", c => c.String(nullable: false));
        }
    }
}
