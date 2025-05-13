using BlogLib;
using System.Data.Entity;

public class BlogContext : DbContext
{
    public BlogContext() : base("BlogDbConnection") { }

    public DbSet<BlogPost> Posts { get; set; }
}