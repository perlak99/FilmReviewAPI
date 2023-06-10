using FilmReviewAPI.Attributes;

namespace FilmReviewAPI.DTOs.Comment
{
    [CommentValidation]
    public class AddCommentDto
    {
        public string Title { get; set; }
        public string Text { get; set; }

        // Comment applies to film or director
        public int? FilmId { get; set; }
        public int? DirectorId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
