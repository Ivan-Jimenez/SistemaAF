namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNacionales : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Nacionales");
            AlterColumn("dbo.Nacionales", "NoActivo", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Nacionales", "NoActivo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Nacionales");
            AlterColumn("dbo.Nacionales", "NoActivo", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Nacionales", "NoActivo");
        }
    }
}
