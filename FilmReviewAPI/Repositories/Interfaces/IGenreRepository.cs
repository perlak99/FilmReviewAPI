using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        public Task<Genre> GetGenreByIdAsync(int id);
        public Task<List<Genre>> GetGenres();
    }
}
