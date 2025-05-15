Imports System
Imports System.Threading.Tasks
Imports BlogClientVb.BlogServiceRef

Module Module1

    Sub Main()
        Task.Run(Async Function()
                     Await RunAsync()
                 End Function).GetAwaiter().GetResult()
    End Sub

    Private Async Function RunAsync() As Task
        Dim client As New BlogServiceClient()
        client.ClientCredentials.UserName.UserName = "admin"
        client.ClientCredentials.UserName.Password = "admin"

        Dim result1 As BlogPost = Await client.AddPostAsync("First Blog", "Hello from WCF!")
        Console.WriteLine($"VB Post added successfully: {result1.Id}")

        Dim result2 As BlogPost = Await client.AddPostAsync("Another Post", "This is a test.")
        Console.WriteLine($"VB Post added successfully: {result2.Id}")

        Dim posts = client.GetPosts()
        For Each post In posts
            Console.WriteLine($"Id: {post.Id} Title: {post.Title}, PostedAt: {post.PostedAt}, Content: {post.Content}")
        Next

        client.Close()
    End Function

End Module
