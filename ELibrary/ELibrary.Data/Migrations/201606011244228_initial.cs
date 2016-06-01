namespace ELibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorName = c.String(),
                        Description = c.String(),
                        PublishYear = c.Int(nullable: false),
                        Snapshot = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Retired = c.Boolean(nullable: false),
                        Tag_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.Tag_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenDate = c.DateTime(nullable: false),
                        CloseDate = c.DateTime(nullable: false),
                        UserEmail = c.String(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Orders", "Book_Id", "dbo.Books");
            DropIndex("dbo.Orders", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "Tag_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Orders");
            DropTable("dbo.Books");
        }
    }
}
