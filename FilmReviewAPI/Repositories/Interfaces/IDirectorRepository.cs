using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IDirectorRepository : IBaseRepository<Director>
    {
        public Task<Director> GetDirectorByIdAsync(int id);

        public Task<List<Director>> GetDirectors();
    }
}
