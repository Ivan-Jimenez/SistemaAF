namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sep30Fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nacionales", "AcomulatedDreprecationLinear", c => c.String());
            DropColumn("dbo.Nacionales", "AcoumatedDrepreciationLinear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nacionales", "AcoumatedDrepreciationLinear", c => c.String());
            DropColumn("dbo.Nacionales", "AcomulatedDreprecationLinear");
        }
    }
}
