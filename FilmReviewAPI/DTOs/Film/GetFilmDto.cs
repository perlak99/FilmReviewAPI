using FilmReviewAPI.DTOs.Comment;
using FilmReviewAPI.Models;

namespace FilmReviewAPI.DTOs.Film
{
    public class GetFilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        //public ICollection<SimpleCommentDto> Comments { get; set; }
        public decimal AverageRating { get; set; }

        public Genre Genre { get; set; }

        //public SimpleDirectorDto Director { get; set; }

    }
}
