using FilmReviewAPI.Enums;
using FilmReviewAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReviewAPI.Models
{
    public class Film : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public int? DirectorId { get; set; }
        public int AddedByUserId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        public ICollection<User> FavouriteUsers { get; set; }

        public int StatusId { get; set; }
        public StatusEnum Status
        {
            get => (StatusEnum)StatusId;
            set => StatusId = (int)value;
        }

        [ForeignKey("AddedByUserId")]
        public User AddedByUser { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        [ForeignKey("DirectorId")]
        public Director? Director { get; set; }
    }
}
