using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        public Task<Director> GetDirectorByIdAsync(int id);
    }
}
