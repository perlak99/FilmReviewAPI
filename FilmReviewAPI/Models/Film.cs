namespace FilmReviewAPI.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
        public Director Director { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
