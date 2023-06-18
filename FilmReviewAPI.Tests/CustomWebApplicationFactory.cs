using FilmReviewAPI.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmReviewAPI.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Retrieve the connection string from the environment variable or appsettings
                var connectionString = Environment.GetEnvironmentVariable("TEST_DATABASE_CONNECTION_STRING") ?? configuration.GetConnectionString("DefaultConnection");

                // Remove dbContext
                services.Remove(services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<FilmReviewDbContext>)));

                // Replace the database context configuration with the test database connection string
                services.AddDbContext<FilmReviewDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });
            });
        }
    }
}
