using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FilmReviewDbContext _dbContext;

        public UserRepository(FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserWithRolesByUsernameAsync(string username)
        {
            return await _dbContext.Users
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User> GetUserWithRolesByIdAsync(int id)
        {
            return await _dbContext.Users
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRoleToUserAsync(User user, Role role)
        {
            user.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
        }
    }
}
