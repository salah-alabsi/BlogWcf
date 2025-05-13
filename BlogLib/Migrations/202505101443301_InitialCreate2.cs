namespace BlogLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BlogPosts");
            AddColumn("dbo.BlogPosts", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.BlogPosts", "Title", c => c.String());
            AddPrimaryKey("dbo.BlogPosts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BlogPosts");
            AlterColumn("dbo.BlogPosts", "Title", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.BlogPosts", "Id");
            AddPrimaryKey("dbo.BlogPosts", "Title");
        }
    }
}
