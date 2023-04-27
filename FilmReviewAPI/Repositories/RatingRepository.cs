using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly FilmReviewDbContext _dbContext;

        public RatingRepository(FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRatingAsync(Rating rating)
        {
            await _dbContext.Ratings.AddAsync(rating);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Rating> FindRatingByUserAndFilmAsync(int filmId, int userId)
        {
           return await _dbContext.Ratings.FirstOrDefaultAsync(x => x.FilmId == filmId && x.UserId == userId);
        }
    }
}
