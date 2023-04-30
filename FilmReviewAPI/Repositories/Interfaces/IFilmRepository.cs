using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IFilmRepository : IBaseRepository<Film>
    {
        public Task<Film> GetFilmByIdAsync(int id);
        public Task<List<Film>> GetFilmsAsync(GetFilmsFilterDto filter);
        public Task<Film> GetFilmByIdWithDetails(int id);
    }
}
