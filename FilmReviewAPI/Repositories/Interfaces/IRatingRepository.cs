using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IRatingRepository : IBaseRepository<Rating>
    {
        public Task<bool> CheckIfRatingByUserAndFilmExistsAsync(int filmId, int userId);
    }
}
