using System.ComponentModel.DataAnnotations;

namespace FilmReviewAPI.DTOs.Auth
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
    }
}
