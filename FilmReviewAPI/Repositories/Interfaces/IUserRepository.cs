using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserWithRolesByUsernameAsync(string username);
        public Task<User> GetUserWithRolesByIdAsync(int id);
        public Task AddUserAsync(User user);
        public Task AddRoleToUserAsync(User user, Role role);
    }
}
