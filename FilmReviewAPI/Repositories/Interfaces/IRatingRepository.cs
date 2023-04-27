using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IRatingRepository : ISaveChanges
    {
        public Task AddRatingAsync(Rating rating);
        public Task<Rating> FindRatingByUserAndFilmAsync(int filmId, int userId);
    }
}
