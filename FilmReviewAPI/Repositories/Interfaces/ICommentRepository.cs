using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<Comment> GetCommentByIdAsync(int id);
    }
}
