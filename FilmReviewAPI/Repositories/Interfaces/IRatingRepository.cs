using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IRatingRepository : IBaseRepository<Rating>
    {
        public Task<Rating> GetRatingByUserAndFilmAsync(int filmId, int userId);
    }
}
