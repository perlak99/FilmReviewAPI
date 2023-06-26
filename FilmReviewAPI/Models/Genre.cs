using FilmReviewAPI.Models.Interfaces;

namespace FilmReviewAPI.Models
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
