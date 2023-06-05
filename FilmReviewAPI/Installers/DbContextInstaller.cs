using FilmReviewAPI.DAL;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void Install(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<FilmReviewDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
        }

    }
}
