using FilmReviewAPI.DTOs.Rating;
using FilmReviewAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("addRating"), Authorize()]
        public async Task<IActionResult> AddRating(AddRatingDto ratingDto)
        {
            try
            {
                var userId = int.Parse(User.Claims.First(i => i.Type == "UserId").Value);
                await _ratingService.AddRatingAsync(ratingDto, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
