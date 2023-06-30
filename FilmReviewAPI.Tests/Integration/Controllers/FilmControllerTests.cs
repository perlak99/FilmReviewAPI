namespace FilmReviewAPI.Tests.Integration.Controllers
{
    public class FilmControllerTests : BaseControllerTests
    {
        public FilmControllerTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetFilm_ReturnsOkResultWithFilmDto()
        {
            // Arrange
            int filmId = 1;

            // Act
            var response = await _client.GetAsync($"/api/Film/getFilm?id={filmId}");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}