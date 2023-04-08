using FilmReviewAPI.DTOs;
using FilmReviewAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpPost("addFilm"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddFilm (FilmDto filmDto)
        {
            try
            {
                await _filmService.AddFilmAsync(filmDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
