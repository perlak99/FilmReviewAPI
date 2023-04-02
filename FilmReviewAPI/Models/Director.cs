namespace FilmReviewAPI.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Film> Films { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
