using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IFilmRepository
    {
        public Task AddFilmAsync(Film film);
        public Task<Film> GetFilmByIdAsync(int id);
        public Task DeleteFilmAsync(Film film);
        public Task SaveAsync();
        public Task<List<Film>> GetFilmsAsync(int page, int pageSize);
        public Task<Film> GetFilmByIdWithDetails(int id);
    }
}
