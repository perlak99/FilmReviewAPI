using FilmReviewAPI.DTOs.Director;

namespace FilmReviewAPI.Services.Interfaces
{
    public interface IDirectorService
    {
        public Task<List<SimpleDirectorDto>> GetDirectorsBySearchPhrase(string phrase);
    }
}
