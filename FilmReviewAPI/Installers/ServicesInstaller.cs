using FilmReviewAPI.Services;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void Install(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IFilmService, FilmService>();
            builder.Services.AddScoped<IRatingService, RatingService>();
            builder.Services.AddScoped<IDirectorService, DirectorService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
        }
    }
}
