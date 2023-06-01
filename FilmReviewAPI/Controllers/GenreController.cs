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

        [HttpGet("getGenresBySearchPhrase")]
        public async Task<ActionResult<DataResponse<List<Genre>>>> GetGenresBySearchPhrase(string phrase)
        {
            var genres = await _genreService.GetGenresBySearchPhrase(phrase);
            return Ok(ResponseFactory.CreateSuccessResponse(genres));
        }
    }
}
