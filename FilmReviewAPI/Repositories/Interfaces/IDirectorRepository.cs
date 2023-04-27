using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IDirectorRepository : ISaveChanges
    {
        public Task<Director> GetDirectorByIdAsync(int id);
    }
}
