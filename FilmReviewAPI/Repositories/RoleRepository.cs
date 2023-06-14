using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(FilmReviewDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _dbContext.Roles
                .FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
