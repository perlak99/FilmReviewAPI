using FilmReviewAPI.Models;

namespace FilmReviewAPI.DTOs
{
    public class FilmDto
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public int? DirectorId { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
