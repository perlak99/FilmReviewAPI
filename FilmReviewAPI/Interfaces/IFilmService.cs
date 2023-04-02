using FilmReviewAPI.DTOs;
using FilmReviewAPI.Models;

namespace FilmReviewAPI.Interfaces
{
    public interface IFilmService
    {
        Task<Film> AddFilmAsync(FilmDto request);
        Task<Film> DeleteFilmAsync(int id);
        Task<Film> UpdateFilmAsync(FilmDto request);


    }
}
