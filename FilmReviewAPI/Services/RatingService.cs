using AutoMapper;
using FilmReviewAPI.DAL;
using FilmReviewAPI.DTOs.Rating;
using FilmReviewAPI.Models;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddRatingAsync(AddRatingDto request, int userId)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var film = await _unitOfWork.FilmRepository.GetFilmByIdAsync(request.FilmId);

            if (film == null)
            {
                throw new ArgumentException("Film not found");
            }

            if (await _unitOfWork.RatingRepository.GetRatingByUserAndFilmAsync(request.FilmId, userId) != null)
            {
                throw new ArgumentException("Film is already rated by this user");
            }

            var rating = _mapper.Map<Rating>(request);
            rating.UserId = userId;
            await _unitOfWork.RatingRepository.AddAsync(rating);
            await _unitOfWork.SaveAsync();
        }
    }
}
