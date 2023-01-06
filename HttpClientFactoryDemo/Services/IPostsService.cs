using HttpClientFactoryDemo.Models;

namespace HttpClientFactoryDemo.Services
{
    public interface IPostsService
    {
        Task<Post> GetPostForId(int id);
        Task<Post[]> GetPosts();
    }
}