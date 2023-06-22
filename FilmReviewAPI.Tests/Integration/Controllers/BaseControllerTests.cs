using Microsoft.AspNetCore.Mvc.Testing;

namespace FilmReviewAPI.Tests.Integration.Controllers
{
    public abstract class BaseControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        protected readonly WebApplicationFactory<Program> _factory;
        protected readonly HttpClient _client;

        public BaseControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }
    }
}
