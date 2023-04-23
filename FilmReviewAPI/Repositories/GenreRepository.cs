using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly FilmReviewDbContext _dbContext;

        public GenreRepository(FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _dbContext.Genres
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
