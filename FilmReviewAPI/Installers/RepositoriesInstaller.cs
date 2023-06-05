using FilmReviewAPI.Repositories;
using FilmReviewAPI.Repositories.Interfaces;

namespace FilmReviewAPI.Installers
{
    public class RepositoriesInstaller : IInstaller
    {
        public void Install(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRatingRepository, RatingRepository>();
            builder.Services.AddScoped<IFilmRepository, FilmRepository>();
            builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
