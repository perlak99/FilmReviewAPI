using FilmReviewAPI.DTOs.Director;

namespace FilmReviewAPI.Services.Interfaces
{
    public interface IDirectorService
    {
        public Task<List<SimpleDirectorDto>> GetDirectors();
        public Task AddDirector(AddDirectorDto request, int userId);
        public Task ChangeDirectorStatus(int directorId, int statusId);
    }
}
