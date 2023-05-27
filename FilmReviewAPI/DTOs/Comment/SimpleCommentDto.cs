using FilmReviewAPI.DTOs.User;

namespace FilmReviewAPI.DTOs.Comment
{
    public class SimpleCommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public SimpleUserDto User { get; set; }
    }
}
