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

        public async Task<List<SimpleDirectorDto>> GetDirectors()
        {
            var directors = await _directorRepository.GetDirectors();

            return _mapper.Map<List<SimpleDirectorDto>>(directors);
        }
    }
}
