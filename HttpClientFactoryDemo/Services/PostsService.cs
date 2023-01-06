using HttpClientFactoryDemo.Models;

namespace HttpClientFactoryDemo.Services
{
    public class PostsService : IPostsService
    {
        private readonly HttpClient _httpClient;
        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Post[]> GetPosts()
        {
            Post[]? posts = await _httpClient.GetFromJsonAsync<Post[]>($"{_httpClient.BaseAddress}posts");
            return posts ?? Array.Empty<Post>();
        }

        public async Task<Post> GetPostForId(int id)
        {
            Post post = await _httpClient.GetFromJsonAsync<Post>($"{_httpClient.BaseAddress}posts/{id}");
            return post;
        }
    }
}
