using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        public Task<Genre> GetGenreByIdAsync(int id);
    }
}
