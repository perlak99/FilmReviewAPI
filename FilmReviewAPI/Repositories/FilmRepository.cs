using FilmReviewAPI.DAL;
using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using FilmReviewAPI.Utils;
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

        public async Task<List<Film>> GetFilmsAsync(GetFilmsFilterDto filter)
        {
            var query = _dbContext.Films
                .Include(f => f.Genre)
                .Include(f => f.Director)
                .Include(f => f.Ratings)
                .Where(f => f.DirectorId == filter.DirectorId, filter.DirectorId != null)
                .Where(f => f.GenreId == filter.GenreId, filter.GenreId != null)
                .Where(f => f.ReleaseYear >= filter.ReleaseYearFrom, filter.ReleaseYearFrom != null)
                .Where(f => f.ReleaseYear <= filter.ReleaseYearTo, filter.ReleaseYearTo != null)
                .Where(f => f.Ratings.Average(x => x.Value) >= filter.MinAverageRating, filter.MinAverageRating != null)
                .Skip(filter.PageSize * filter.Page)
                .Take(filter.PageSize);

            return await query.ToListAsync();
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
