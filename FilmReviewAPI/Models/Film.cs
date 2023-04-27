using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReviewAPI.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public int? DirectorId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        [ForeignKey("DirectorId")]
        public Director Director { get; set; }
    }
}
