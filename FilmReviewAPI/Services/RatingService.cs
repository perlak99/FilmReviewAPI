using AutoMapper;
using FilmReviewAPI.DTOs.Rating;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Services
{
    public class RatingService : IRatingService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IMapper mapper, IRatingRepository ratingRepository, IFilmRepository filmRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _filmRepository = filmRepository;
            _userRepository = userRepository;
        }

        public async Task AddRatingAsync(AddRatingDto request, int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var film = await _filmRepository.GetFilmByIdAsync(request.FilmId);

            if (film == null)
            {
                throw new ArgumentException("Film not found");
            }

            if (await _ratingRepository.GetRatingByUserAndFilmAsync(request.FilmId, userId) != null)
            {
                throw new ArgumentException("Film is already rated by this user");
            }

            var rating = _mapper.Map<Rating>(request);
            rating.UserId = userId;
            await _ratingRepository.AddAsync(rating);
        }
    }
}
