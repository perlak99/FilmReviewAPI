using FilmReviewAPI.DTOs.Director;
using FilmReviewAPI.Response;
using FilmReviewAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet("getDirectors")]
        public async Task<ActionResult<DataResponse<List<SimpleDirectorDto>>>> GetDirectors()
        {
            var directors = await _directorService.GetDirectors();
            return Ok(ResponseFactory.CreateSuccessResponse(directors));
        }
    }
}
