using FilmReviewAPI.DAL;
using FilmReviewAPI.Models;
using FilmReviewAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmReviewAPI.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(FilmReviewDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            return await _dbContext.Comments
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
