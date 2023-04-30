using FilmReviewAPI.Repositories;
using FilmReviewAPI.Repositories.Interfaces;

namespace FilmReviewAPI.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FilmReviewDbContext _dbContext;
        public IDirectorRepository DirectorRepository { get; private set; }

        public IFilmRepository FilmRepository { get; private set; }

        public IGenreRepository GenreRepository { get; private set; }

        public IRatingRepository RatingRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IRoleRepository RoleRepository { get; private set; }

        public UnitOfWork(FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;

            DirectorRepository = new DirectorRepository(dbContext);
            FilmRepository = new FilmRepository(dbContext);
            GenreRepository = new GenreRepository(dbContext);
            RatingRepository = new RatingRepository(dbContext);
            UserRepository = new UserRepository(dbContext);
            RoleRepository = new RoleRepository(dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
