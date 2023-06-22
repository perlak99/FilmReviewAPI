﻿using System.Net;

namespace FilmReviewAPI.Tests.IntegrationTests.Controllers
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
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}