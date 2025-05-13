using BlogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace BlogLib
{
    public class BlogService : IBlogService
    {
        //public void AddPost(string title, string content)
        //{
        //    var post = new BlogPost
        //    {
        //        Title = title,
        //        Content = content,
        //        PostedAt = DateTime.Now
        //    };

        //    using (var db = new BlogContext())
        //    {
        //        db.Posts.Add(post);
        //        db.SaveChanges();
        //    }
        //}
        public async Task<BlogPost> AddPostAsync(string title, string content)
        {
            var user = Thread.CurrentPrincipal;
            Console.WriteLine($"==> IsAuthenticated: {user.Identity.IsAuthenticated}, Name: {user.Identity.Name}");

            //if (user is GenericPrincipal gp)
            //{
            //    Console.WriteLine("==> Roles: " + string.Join(",", gp.Roles));
            //}
            Console.WriteLine("come here");
            if (!PermissionChecker.CurrentUserHasPermission("add-post"))
                throw new UnauthorizedAccessException("You do not have permission to add posts.");
            Console.WriteLine($"inside ------> Adding post: {title} at {DateTime.Now}");
            var post = new BlogPost
            {
                Title = title,
                Content = content,
                PostedAt = DateTime.Now
            };

            using (var db = new BlogContext())
            {
                db.Posts.Add(post);
                await db.SaveChangesAsync();
            }
            return post; // إرجاع الكائن الذي تم إدخاله
        }

        public List<BlogPost> GetPosts()
        {
            using (var db = new BlogContext())
            {
                return db.Posts.ToList();
            }
        }
    }
}