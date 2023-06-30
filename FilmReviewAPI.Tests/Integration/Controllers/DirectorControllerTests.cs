using FilmReviewAPI.DAL;
using FilmReviewAPI.DTOs.Director;
using Microsoft.Extensions.DependencyInjection;

namespace FilmReviewAPI.Tests.Integration.Controllers
{
    public class DirectorControllerTests : BaseControllerTests
    {
        public DirectorControllerTests(CustomWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task AddDirector_ReturnsOkResult()
        {
            // Arrange
            await AuthenticateAsAdminAsync();

            var director = new AddDirectorDto()
            {
                FirstName = "Testtttfirstname",
                LastName = "Testlastname",
                DateOfBirth = new DateTime(2000, 8, 10)
            };

            // Act
            var response = await _client.PostAsync("/api/Director/addDirector", TestHelper.ParseToHttpContent(director));

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
