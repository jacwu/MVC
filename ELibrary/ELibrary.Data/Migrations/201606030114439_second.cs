namespace ELibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.Books", new[] { "Tag_Id" });
            CreateTable(
                "dbo.TagBooks",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Book_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "Tag_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Tag_Id", c => c.Int());
            DropForeignKey("dbo.TagBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.TagBooks", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagBooks", new[] { "Book_Id" });
            DropIndex("dbo.TagBooks", new[] { "Tag_Id" });
            DropTable("dbo.TagBooks");
            CreateIndex("dbo.Books", "Tag_Id");
            AddForeignKey("dbo.Books", "Tag_Id", "dbo.Tags", "Id");
        }
    }
}
