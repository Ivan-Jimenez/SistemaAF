namespace SistemaAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Extranjeros", "Image", c => c.String());
            AddColumn("dbo.Nacionales", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nacionales", "Image");
            DropColumn("dbo.Extranjeros", "Image");
        }
    }
}
