using FilmReviewAPI.Enums;
using FilmReviewAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReviewAPI.Models
{
    public class Director : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Film> Films { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StatusId { get; set; }
        public StatusEnum Status
        {
            get => (StatusEnum)StatusId;
            set => StatusId = (int)value;
        }
        public int AddedByUserId { get; set; }

        [ForeignKey("AddedByUserId")]
        public User AddedByUser { get; set; }
    }
}
