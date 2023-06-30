using System.Text;
using System.Text.Json;

namespace FilmReviewAPI.Tests
{
    internal static class TestHelper
    {
        public static HttpContent ParseToHttpContent<T>(T data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }
    }
}
