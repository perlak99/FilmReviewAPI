using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FilmReviewAPI.Tests.IntegrationTests.Controllers
{
    public class FilmControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public FilmControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetFilm_ReturnsOkResultWithFilmDto()
        {
            // Arrange
            var client = _factory.CreateClient();
            int filmId = 1;

            // Act
            var response = await client.GetAsync($"/api/Film/getFilm?id={filmId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert the response body and its properties as needed
        }
    }
}