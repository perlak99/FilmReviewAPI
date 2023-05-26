using AutoMapper;
using FilmReviewAPI.DTOs.Film;
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

        public async Task AddFilmAsync(AddFilmDto request)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(request.GenreId);
            if (genre == null)
            {
                throw new ArgumentException("Genre not found");
            }

            if (request.DirectorId != null)
            {
                var director = await _directorRepository.GetDirectorByIdAsync((int)request.DirectorId);
                if (director == null)
                {
                    throw new ArgumentException("Director not found");
                }
            }

            var film = _mapper.Map<Film>(request);
            await _filmRepository.AddAsync(film);
        }

        public async Task DeleteFilmAsync(int id)
        {
            var film = await _filmRepository.GetFilmByIdAsync(id);

            if (film == null)
            {
                throw new ArgumentException("Film not found");
            }

            await _filmRepository.RemoveAsync(film);
        }

        public async Task UpdateFilmAsync(UpdateFilmDto request)
        {
            var film = await _filmRepository.GetFilmByIdAsync(request.Id);

            if (film == null)
            {
                throw new ArgumentException("Film not found");
            }

            var genre = await _genreRepository.GetGenreByIdAsync(request.GenreId);
            if (genre == null)
            {
                throw new ArgumentException("Genre not found");
            }

            if (request.DirectorId != null)
            {
                var director = await _directorRepository.GetDirectorByIdAsync((int)request.DirectorId);
                if (director == null)
                {
                    throw new ArgumentException("Director not found");
                }
            }

            film = _mapper.Map<Film>(request);

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
