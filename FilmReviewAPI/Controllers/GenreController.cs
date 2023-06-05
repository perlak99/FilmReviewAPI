using FilmReviewAPI.Models;
using FilmReviewAPI.Response;
using FilmReviewAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("getGenres")]
        public async Task<ActionResult<DataResponse<List<Genre>>>> GetGenres()
        {
            var genres = await _genreService.GetGenres();
            return Ok(ResponseFactory.CreateSuccessResponse(genres));
        }
    }
}
