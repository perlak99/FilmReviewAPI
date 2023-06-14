using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IDirectorRepository : IBaseRepository<Director>
    {
        public Task<List<Director>> GetDirectors();
    }
}
