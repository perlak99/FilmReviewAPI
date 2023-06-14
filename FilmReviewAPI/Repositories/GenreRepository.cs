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

        public async Task<List<Genre>> GetGenres()
        {
            return await _dbContext.Genres
                .ToListAsync();
        }
    }
}
