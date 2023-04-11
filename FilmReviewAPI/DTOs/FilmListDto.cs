using FilmReviewAPI.Models;

namespace FilmReviewAPI.DTOs
{
    public class FilmListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }

        public Genre Genre { get; set; }

        public Director Director { get; set; }
    }
}
