using System.Text.Json.Serialization;

namespace HttpClientFactoryDemo.Models
{
    public record Post(int UserId, int Id, string Title, string Body);
}
