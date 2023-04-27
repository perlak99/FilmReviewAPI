namespace FilmReviewAPI.DTOs.Film
{
    public class UpdateFilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public int? DirectorId { get; set; }
    }
}
