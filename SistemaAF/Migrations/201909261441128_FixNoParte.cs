namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNoParte : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Extranjeros");
            AlterColumn("dbo.Extranjeros", "NoParte", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Extranjeros", "NoParte");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Extranjeros");
            AlterColumn("dbo.Extranjeros", "NoParte", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Extranjeros", "NoParte");
        }
    }
}
