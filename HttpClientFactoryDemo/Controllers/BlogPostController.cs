using HttpClientFactoryDemo.Models;
using HttpClientFactoryDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HttpClientFactoryDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogPostController : ControllerBase
    {
        private readonly ILogger<BlogPostController> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IPostsService postsService;

        public BlogPostController(ILogger<BlogPostController> logger, IHttpClientFactory httpClientFactory, IPostsService postsService)
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
            this.postsService = postsService;
        }

        [HttpGet("GetByCreateClient")]
        public async Task<Post[]> GetByCreateClient()
        {
            HttpClient httpClient = this.httpClientFactory.CreateClient();
            var result = await httpClient.GetFromJsonAsync<Post[]>("https://jsonplaceholder.typicode.com/posts/");
            return result ?? Array.Empty<Post>();
        }

        [HttpGet("GetByNamedClient")]
        public async Task<Post[]> GetByNamedClient()
        {
            HttpClient httpClient = this.httpClientFactory.CreateClient("namedClient");
            var result = await httpClient.GetFromJsonAsync<Post[]>($"{httpClient.BaseAddress}posts");
            return result ?? Array.Empty<Post>();
        }

        [HttpGet("GetByTypedClient")]
        public async Task<Post[]> GetByTypedClient()
        {
            return await this.postsService.GetPosts();
        }
    }
}