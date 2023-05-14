using FilmReviewAPI.Models;

namespace FilmReviewAPI.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetCommentByIdAsync(int id);
    }
}
