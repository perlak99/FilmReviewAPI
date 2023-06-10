using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReviewAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        // Comment applies to film or director
        [ForeignKey("Film")]
        public int? FilmId { get; set; }
        public Film? Film { get; set; }

        [ForeignKey("Director")]
        public int? DirectorId { get; set; }
        public Director? Director { get; set; }

        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }

        public List<Comment>? Replies { get; set; }
    }
}
