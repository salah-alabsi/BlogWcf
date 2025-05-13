using BlogClient.BlogServiceReference;
using System;
using System.Threading.Tasks;

namespace BlogClient
{
    class Program
    {
        static async Task Main(string[] args)  // تغيير هنا إلى async Task
        {
            BlogServiceClient client = new BlogServiceClient();
            client.ClientCredentials.UserName.UserName = "alice";
            client.ClientCredentials.UserName.Password = "pass";
            BlogPost result1 = await client.AddPostAsync("First Blog", "Hello from WCF!");
            Console.WriteLine($"Post added successfully: {result1.Id} ");
            BlogPost result2=await  client.AddPostAsync("Another Post", "This is a test.");
            Console.WriteLine( $"Post added successfully: {result2.Id} ");
            var posts = client.GetPosts();
            foreach (var post in posts)
            {
                Console.WriteLine($"Id: {post.Id} Title: {post.Title}, PostedAt: {post.PostedAt}, Content: {post.Content}");
            }

            client.Close();
        }
    }
}
