namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sep30Fix2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nacionales", "AcomulatedDeprecationLinear", c => c.String());
            DropColumn("dbo.Nacionales", "AcomulatedDreprecationLinear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nacionales", "AcomulatedDreprecationLinear", c => c.String());
            DropColumn("dbo.Nacionales", "AcomulatedDeprecationLinear");
        }
    }
}
