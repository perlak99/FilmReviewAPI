using FilmReviewAPI.DTOs.Rating;

namespace FilmReviewAPI.Services.Interfaces
{
    public interface IRatingService
    {
        public Task AddRatingAsync(AddRatingDto request, int userId);
    }
}
