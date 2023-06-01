using AutoMapper;
using FilmReviewAPI.DTOs.Director;
using FilmReviewAPI.Repositories.Interfaces;
using FilmReviewAPI.Services.Interfaces;

namespace FilmReviewAPI.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorService(IMapper mapper, IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public async Task<List<SimpleDirectorDto>> GetDirectorsBySearchPhrase(string phrase)
        {
            var directors = await _directorRepository.GetDirectorsBySearchPhrase(phrase);

            return _mapper.Map<List<SimpleDirectorDto>>(directors);
        }
    }
}
