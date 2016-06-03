namespace ELibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImageName", c => c.String());
            AddColumn("dbo.Tags", "ImageName", c => c.String());
            DropColumn("dbo.Books", "Snapshot");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Snapshot", c => c.String());
            DropColumn("dbo.Tags", "ImageName");
            DropColumn("dbo.Books", "ImageName");
        }
    }
}
