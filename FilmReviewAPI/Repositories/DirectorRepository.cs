using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly FilmReviewDbContext _dbContext;

        public DirectorRepository(FilmReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Director> GetDirectorByIdAsync(int id)
        {
            return await _dbContext.Directors
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
