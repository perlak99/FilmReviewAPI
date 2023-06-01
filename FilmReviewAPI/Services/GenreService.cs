using AutoMapper;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IMapper mapper, IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<List<Genre>> GetGenresBySearchPhrase(string phrase)
        {
            var genres = await _genreRepository.GetGenresBySearchPhrase(phrase);

            return genres;
        }
    }
}
