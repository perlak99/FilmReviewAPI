using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(FilmReviewDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Director>> GetDirectors()
        {
            return await _dbContext.Directors
                .Where(x => x.Status == Enums.StatusEnum.Accepted)
                .ToListAsync();
        }
    }
}
