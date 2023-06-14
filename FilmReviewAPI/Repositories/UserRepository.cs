using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FilmReviewDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> CheckIfExistsByUsername(string username)
        {
            return await _dbContext.Users.AnyAsync(x => x.Username == username);
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
    }
}
