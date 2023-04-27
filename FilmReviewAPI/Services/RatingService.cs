using AutoMapper;
using FilmReviewAPI.DTOs.Rating;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IUserRepository userRepository, IFilmRepository filmRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task AddRatingAsync(AddRatingDto request, int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var film = await _filmRepository.GetFilmByIdAsync(request.FilmId);

            if (film == null)
            {
                throw new Exception("Film not found");
            }

            if (await _ratingRepository.FindRatingByUserAndFilmAsync(request.FilmId, userId) != null)
            {
                throw new Exception("Film is already rated by this user");
            }

            var rating = _mapper.Map<Rating>(request);
            rating.UserId = userId;
            await _ratingRepository.AddRatingAsync(rating);
            await _ratingRepository.SaveAsync();
        }
    }
}
