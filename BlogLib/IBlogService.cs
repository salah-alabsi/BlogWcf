using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace BlogLib
{
    [ServiceContract]
    public interface IBlogService
    {
        //[OperationContract]
        //void AddPost(string title, string content);
        [OperationContract]
        Task<BlogPost> AddPostAsync(string title, string content);


        [OperationContract]
        List<BlogPost> GetPosts();
    }
}
