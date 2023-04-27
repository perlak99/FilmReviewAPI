using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly FilmReviewDbContext _dbContext;

        public FilmRepository(FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddFilmAsync(Film film)
        {
            await _dbContext.AddAsync(film);
        }

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            return await _dbContext.Films.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteFilmAsync(Film film)
        {
            _dbContext.Films.Remove(film);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Film>> GetFilmsAsync(int skipCount, int pageSize)
        {
            return await _dbContext.Films
                .Include(f => f.Genre)
                .Include(f => f.Director)
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Film> GetFilmByIdWithDetails(int id)
        {
            return await _dbContext.Films
                .Include(f => f.Genre)
                .Include(f => f.Director)
                .Include(f => f.Comments)
                .Include(f => f.Ratings)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
