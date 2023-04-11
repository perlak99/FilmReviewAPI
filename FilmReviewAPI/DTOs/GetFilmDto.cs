using FilmReviewAPI.Models;

namespace FilmReviewAPI.DTOs
{
    public class GetFilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Genre Genre { get; set; }

        public Director Director { get; set; }

    }
}
