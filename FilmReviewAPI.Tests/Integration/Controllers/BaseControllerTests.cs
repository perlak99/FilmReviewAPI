using FilmReviewAPI.DTOs.Auth;
using FilmReviewAPI.Response;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace FilmReviewAPI.Tests.Integration.Controllers
{
    public abstract class BaseControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        protected readonly WebApplicationFactory<Program> _factory;
        protected readonly HttpClient _client;

        protected const string AdminUsername = "admin";
        protected const string AdminPassword = "admin";

        public BaseControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        protected async Task AuthenticateAsAdminAsync()
        {
            await AuthenticateClientAsync(AdminUsername, AdminPassword);
        }

        //protected async Task AuthenticateAsUserAsync()
        //{
        //    await AuthenticateClientAsync(UserUsername, UserPassword);
        //}

        private async Task AuthenticateClientAsync(string username, string password)
        {
            var authenticateDto = new AuthenticateDto
            {
                Username = username,
                Password = password
            };

            var response = await _client.PostAsync("/api/User/authenticate", TestHelper.ParseToHttpContent(authenticateDto));
            response.EnsureSuccessStatusCode();

            // Extract and set the authentication token from the response
            var responseObject = await response.Content.ReadFromJsonAsync<DataResponse<string>>();
            var token = responseObject.Data;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
