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
    }
}
