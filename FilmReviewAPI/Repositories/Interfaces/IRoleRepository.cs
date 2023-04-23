using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public Task<Role> GetRoleByNameAsync(string name);
        public Task<Role> GetRoleByIdAsync(int id);
    }
}
