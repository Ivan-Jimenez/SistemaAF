namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreign1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Extranjeros", "DescIng", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Extranjeros", "DescIng");
        }
    }
}
