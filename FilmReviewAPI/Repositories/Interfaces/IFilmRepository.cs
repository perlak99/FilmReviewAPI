using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IFilmRepository : ISaveChanges
    {
        public Task AddFilmAsync(Film film);
        public Task<Film> GetFilmByIdAsync(int id);
        public Task DeleteFilmAsync(Film film);
        public Task<List<Film>> GetFilmsAsync(int page, int pageSize);
        public Task<Film> GetFilmByIdWithDetails(int id);
    }
}
