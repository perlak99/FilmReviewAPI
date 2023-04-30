using AutoMapper;
using FilmReviewAPI.DAL;
using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Models;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Services
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FilmService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddFilmAsync(AddFilmDto request)
        {
            var genre = await _unitOfWork.GenreRepository.GetGenreByIdAsync(request.GenreId);
            if (genre == null)
            {
                throw new ArgumentException("Genre not found");
            }

            if (request.DirectorId != null)
            {
                var director = await _unitOfWork.DirectorRepository.GetDirectorByIdAsync((int)request.DirectorId);
                if (director == null)
                {
                    throw new ArgumentException("Director not found");
                }
            }

            var film = _mapper.Map<Film>(request);
            await _unitOfWork.FilmRepository.AddAsync(film);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteFilmAsync(int id)
        {
            var film = await _unitOfWork.FilmRepository.GetFilmByIdAsync(id);

            if (film == null)
            {
                throw new ArgumentException("Film not found");
            }

            _unitOfWork.FilmRepository.Remove(film);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateFilmAsync(UpdateFilmDto request)
        {
            var film = await _unitOfWork.FilmRepository.GetFilmByIdAsync(request.Id);

            if (film == null)
            {
                throw new ArgumentException("Film not found");
            }

            var genre = await _unitOfWork.GenreRepository.GetGenreByIdAsync(request.GenreId);
            if (genre == null)
            {
                throw new ArgumentException("Genre not found");
            }

            if (request.DirectorId != null)
            {
                var director = await _unitOfWork.DirectorRepository.GetDirectorByIdAsync((int)request.DirectorId);
                if (director == null)
                {
                    throw new ArgumentException("Director not found");
                }
            }

            film = _mapper.Map<Film>(request);

            await _unitOfWork.SaveAsync();
        }

        public async Task<List<FilmListDto>> GetFilmsAsync(GetFilmsFilterDto filter)
        {
            var films = await _unitOfWork.FilmRepository.GetFilmsAsync(filter);

            return _mapper.Map<List<FilmListDto>>(films);
        }

        public async Task<GetFilmDto> GetFilmAsync(int id)
        {
            var film = await _unitOfWork.FilmRepository.GetFilmByIdWithDetails(id);

            if (film == null)
            {
                throw new ArgumentException("Film not found");
            }

            var filmDto = _mapper.Map<GetFilmDto>(film);
            filmDto.AverageRating = film.Ratings.Any() ? film.Ratings.Average(r => r.Value) : 0;

            return filmDto;
        }
    }
}
