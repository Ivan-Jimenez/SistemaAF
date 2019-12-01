namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nacionales", "ActivationDate", c => c.String());
            AddColumn("dbo.Nacionales", "SerialNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nacionales", "SerialNumber");
            DropColumn("dbo.Nacionales", "ActivationDate");
        }
    }
}
