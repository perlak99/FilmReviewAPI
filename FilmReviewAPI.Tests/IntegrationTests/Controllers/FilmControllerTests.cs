using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FilmReviewAPI.Tests.IntegrationTests.Controllers
{
    public class FilmControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public FilmControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    // Retrieve the connection string from the environment variable
                    var connectionString = Environment.GetEnvironmentVariable("TEST_DATABASE_CONNECTION_STRING");

                    // Remove dbContext
                    services.Remove(services.SingleOrDefault( d => d.ServiceType == typeof(DbContextOptions<FilmReviewDbContext>)));

                    // Replace the database context configuration with the test database connection string
                    services.AddDbContext<FilmReviewDbContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });
                });
            });
        }

        [Fact]
        public async Task GetFilm_ReturnsOkResultWithFilmDto()
        {
            // Arrange
            var client = _factory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:7130");
            int filmId = 5;

            // Act
            var response = await client.GetAsync($"/api/Film/getFilm?id={filmId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert the response body and its properties as needed
        }
    }
}