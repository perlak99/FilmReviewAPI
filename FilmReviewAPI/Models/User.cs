namespace FilmReviewAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Film> FavouriteFilms { get; set; }
        public ICollection<Film> AddedFilms { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
