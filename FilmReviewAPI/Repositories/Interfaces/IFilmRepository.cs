using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IFilmRepository : ISaveChanges
    {
        public Task AddFilmAsync(Film film);
        public Task<Film> GetFilmByIdAsync(int id);
        public Task DeleteFilmAsync(Film film);
        public Task<List<Film>> GetFilmsAsync(GetFilmsFilterDto filter);
        public Task<Film> GetFilmByIdWithDetails(int id);
    }
}
