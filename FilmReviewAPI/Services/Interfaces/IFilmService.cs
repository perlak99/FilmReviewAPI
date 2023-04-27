using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Models;

namespace FilmReviewAPI.Services.Interfaces
{
    public interface IFilmService
    {
        Task<GetFilmDto> GetFilmAsync(int id);
        Task<List<FilmListDto>> GetFilmsAsync(int page, int pageSize);
        Task AddFilmAsync(AddFilmDto request);
        Task DeleteFilmAsync(int id);
        Task UpdateFilmAsync(UpdateFilmDto request);
    }
}
