using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> GetUserByUsernameAsync(string username);
        public Task<User> GetUserWithRolesByUsernameAsync(string username);
        public Task<User> GetUserWithRolesByIdAsync(int id);
        public Task<bool> CheckIfExistsByUsername(string username);
        public Task<bool> CheckIfExistsByEmail(string email);
    }
}
