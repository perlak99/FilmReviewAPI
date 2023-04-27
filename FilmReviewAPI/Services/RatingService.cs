using FilmReviewAPI.Repositories.Interfaces;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public Task AddRating()
        {
            throw new NotImplementedException();
        }
    }
}
