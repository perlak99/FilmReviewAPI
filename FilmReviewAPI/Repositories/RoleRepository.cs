using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly FilmReviewDbContext _dbContext;

        public RoleRepository(FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _dbContext.Roles
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _dbContext.Roles
                .FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
