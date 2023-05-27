using FilmReviewAPI.DTOs.Director;
using FilmReviewAPI.Models;

namespace FilmReviewAPI.DTOs.Film
{
    public class GetFilmListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }

        public Genre Genre { get; set; }

        public SimpleDirectorDto Director { get; set; }
    }
}
