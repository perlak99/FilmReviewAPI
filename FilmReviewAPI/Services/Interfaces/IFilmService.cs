using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Models;

namespace FilmReviewAPI.Services.Interfaces
{
    public interface IFilmService
    {
        Task<GetFilmDto> GetFilmAsync(int id);
        Task<List<GetFilmListDto>> GetFilmsAsync(FilmsFilterDto filter);
        Task AddFilmAsync(AddFilmDto request, int userId);
        Task DeleteFilmAsync(int id);
        Task UpdateFilmAsync(UpdateFilmDto request);

        Task ChangeFilmStatus(int filmId, int statusId);
    }
}
