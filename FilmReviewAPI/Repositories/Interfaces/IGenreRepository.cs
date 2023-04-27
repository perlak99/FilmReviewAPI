using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IGenreRepository : ISaveChanges
    {
        public Task<Genre> GetGenreByIdAsync(int id);
    }
}
