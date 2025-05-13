namespace BlogLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                        PostedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Title);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogPosts");
        }
    }
}
