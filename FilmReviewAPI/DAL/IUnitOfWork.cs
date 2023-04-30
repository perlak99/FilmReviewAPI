using FilmReviewAPI.Repositories.Interfaces;

namespace FilmReviewAPI.DAL
{
    public interface IUnitOfWork
    {
        public Task SaveAsync();
        IDirectorRepository DirectorRepository { get; }
        IFilmRepository FilmRepository { get; }
        IGenreRepository GenreRepository { get; }
        IRatingRepository RatingRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; } 
    }
}
