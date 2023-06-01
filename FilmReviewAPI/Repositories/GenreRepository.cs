using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(FilmReviewDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _dbContext.Genres
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Genre>> GetGenresBySearchPhrase(string phrase)
        {
            return await _dbContext.Genres
                .Where(x => x.Name.Contains(phrase))
                .Take(5)
                .ToListAsync();
        }
    }
}
