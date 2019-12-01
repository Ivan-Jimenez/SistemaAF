namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Documents1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "NoAsset", c => c.String(nullable: false));
            AddColumn("dbo.Documents", "AssetType", c => c.String());
            DropColumn("dbo.Documents", "NoActivo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Documents", "NoActivo", c => c.String(nullable: false));
            DropColumn("dbo.Documents", "AssetType");
            DropColumn("dbo.Documents", "NoAsset");
        }
    }
}
