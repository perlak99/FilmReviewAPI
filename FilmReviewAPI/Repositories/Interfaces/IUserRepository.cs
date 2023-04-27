using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface IUserRepository : ISaveChanges
    {
        public Task<User> GetUserByUsernameAsync(string username);
        public Task<User> GetUserWithRolesByUsernameAsync(string username);
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> GetUserWithRolesByIdAsync(int id);
        public Task AddUserAsync(User user);
    }
}
