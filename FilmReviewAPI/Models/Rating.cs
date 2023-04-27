using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReviewAPI.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Range(1,10)]
        public int Value { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("FilmId")]
        public Film Film { get; set; }
    }
}
