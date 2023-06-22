using AutoMapper;
using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Enums;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Services
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IDirectorRepository _directorRepository;

        public FilmService(IMapper mapper, IDirectorRepository directorRepository, IFilmRepository filmRepository, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _directorRepository = directorRepository;
            _filmRepository = filmRepository;
            _genreRepository = genreRepository;
        }

        public async Task AddFilmAsync(AddFilmDto request, int userId)
        {
            if (await _genreRepository.CheckIfExistsById((int)request.GenreId))
            {
                throw new ArgumentException("Genre not found");
            }

            if (request.DirectorId != null)
            {
                if (await _directorRepository.CheckIfExistsById((int)request.DirectorId))
                {
                    throw new ArgumentException("Director not found");
                }
            }

            var film = _mapper.Map<Film>(request);
            film.AddedByUserId = userId;
            film.Status = FilmStatusEnum.Pending;
            await _filmRepository.AddAsync(film);
        }

        public async Task DeleteFilmAsync(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);

            if (film == null)
            {
                throw new ArgumentException("Film not found");
            }

            await _filmRepository.RemoveAsync(film);
        }

        public async Task UpdateFilmAsync(UpdateFilmDto request)
        {
            if (!await _filmRepository.CheckIfExistsById(request.Id))
            {
                throw new ArgumentException("Film not found");
            }

            if (!await _genreRepository.CheckIfExistsById(request.GenreId))
            {
                throw new ArgumentException("Genre not found");
            }

            if (request.DirectorId != null)
            {
                if (!await _directorRepository.CheckIfExistsById((int)request.DirectorId))
                {
                    throw new ArgumentException("Director not found");
                }
            }

            var film = _mapper.Map<Film>(request);

            await _filmRepository.UpdateAsync(film);
        }

        public async Task<List<GetFilmListDto>> GetFilmsAsync(FilmsFilterDto filter)
        {
            var films = await _filmRepository.GetFilmsAsync(filter);

            return _mapper.Map<List<GetFilmListDto>>(films);
        }

        public async Task<GetFilmDto> GetFilmAsync(int id)
        {
            var film = await _filmRepository.GetFilmByIdWithDetails(id);

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
