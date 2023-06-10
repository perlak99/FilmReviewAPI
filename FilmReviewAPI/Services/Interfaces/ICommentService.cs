using FilmReviewAPI.DTOs.Comment;

namespace FilmReviewAPI.Services.Interfaces
{
    public interface ICommentService
    {
        public Task AddCommentAsync(AddCommentDto commentDto, int userId);
    }
}
