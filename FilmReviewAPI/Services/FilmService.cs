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
        private readonly IFilmRepository _filmRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IDirectorRepository _directorRepository;

        public FilmService(IMapper mapper, IFilmRepository filmRepository, IGenreRepository genreRepository, IDirectorRepository directorRepository)
        {
            _filmRepository = filmRepository;
            _genreRepository = genreRepository;
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public async Task AddFilmAsync(AddFilmDto request)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(request.GenreId);
            if (genre == null)
            {
                throw new Exception("Genre not found");
            }

            if (request.DirectorId != null)
            {
                var director = await _directorRepository.GetDirectorByIdAsync((int)request.DirectorId);
                if (director == null)
                {
                    throw new Exception("Director not found");
                }
            }

            var film = _mapper.Map<Film>(request);
            await _filmRepository.AddFilmAsync(film);
            await _filmRepository.SaveAsync();
        }

        public async Task DeleteFilmAsync(int id)
        {
            var film = await _filmRepository.GetFilmByIdAsync(id);

            if (film == null)
            {
                throw new Exception("Film not found");
            }

            await _filmRepository.DeleteFilmAsync(film);
            await _filmRepository.SaveAsync();
        }

        public async Task UpdateFilmAsync(UpdateFilmDto request)
        {
            var film = await _filmRepository.GetFilmByIdAsync(request.Id);

            if (film == null)
            {
                throw new Exception("Film not found");
            }

            var genre = await _genreRepository.GetGenreByIdAsync(request.GenreId);
            if (genre == null)
            {
                throw new Exception("Genre not found");
            }

            if (request.DirectorId != null)
            {
                var director = await _directorRepository.GetDirectorByIdAsync((int)request.DirectorId);
                if (director == null)
                {
                    throw new Exception("Director not found");
                }
            }

            film = _mapper.Map<Film>(request);

            await _filmRepository.SaveAsync();
        }

        public async Task<List<FilmListDto>> GetFilmsAsync(GetFilmsFilterDto filter)
        {
            var films = await _filmRepository.GetFilmsAsync(filter);

            return _mapper.Map<List<FilmListDto>>(films);
        }

        public async Task<GetFilmDto> GetFilmAsync(int id)
        {
            var film = await _filmRepository.GetFilmByIdWithDetails(id);

            if (film == null)
            {
                throw new Exception("Film not found");
            }

            var filmDto = _mapper.Map<GetFilmDto>(film);
            filmDto.AverageRating = film.Ratings.Any() ? film.Ratings.Average(r => r.Value) : 0;

            return filmDto;
        }
    }
}
