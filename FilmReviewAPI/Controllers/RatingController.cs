using FilmReviewAPI.DTOs.Rating;
using FilmReviewAPI.Response;
using FilmReviewAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<ActionResult<BaseResponse>> AddRating(AddRatingDto ratingDto)
        {
            var userId = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
            await _ratingService.AddRatingAsync(ratingDto, userId);
            return Ok(ResponseFactory.CreateSuccessResponse());
        }
    }
}
