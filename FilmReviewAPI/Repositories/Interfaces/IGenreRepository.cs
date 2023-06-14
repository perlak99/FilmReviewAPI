using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        public Task<List<Genre>> GetGenres();
    }
}
