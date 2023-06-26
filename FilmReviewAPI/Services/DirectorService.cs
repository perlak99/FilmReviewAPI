using AutoMapper;
using FilmReviewAPI.DTOs.Director;
using FilmReviewAPI.Enums;
using FilmReviewAPI.Models;
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

        public async Task AddDirector(AddDirectorDto request, int userId)
        {
            var director = _mapper.Map<Director>(request);
            director.AddedByUserId = userId;
            director.Status = StatusEnum.Pending;
            await _directorRepository.AddAsync(director);
        }

        public async Task<List<SimpleDirectorDto>> GetDirectors()
        {
            var directors = await _directorRepository.GetDirectors();

            return _mapper.Map<List<SimpleDirectorDto>>(directors);
        }

        public async Task ChangeDirectorStatus(int directorId, int statusId)
        {
            if (!Enum.IsDefined(typeof(StatusEnum), statusId))
            {
                throw new ArgumentException("Invalid status");
            }

            var director = await _directorRepository.GetByIdAsync(directorId);
            if (director == null)
            {
                throw new ArgumentException("Director not found");
            }

            director.Status = (StatusEnum)statusId;

            await _directorRepository.UpdateAsync(director);
        }

    }
}
