using FilmReviewAPI.Models.Interfaces;

namespace FilmReviewAPI.Models
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
