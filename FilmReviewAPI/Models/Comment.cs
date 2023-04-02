namespace FilmReviewAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Film? Film { get; set; }
        public Director? Director { get; set; }
    }
}
