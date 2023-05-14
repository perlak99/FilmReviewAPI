using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Services.Interfaces;
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
        public async Task<IActionResult> AddFilm (AddFilmDto filmDto)
        {
            await _filmService.AddFilmAsync(filmDto);
            return Ok(new { message = "Film added" });
        }

        [HttpGet("getFilm")]
        public async Task<IActionResult> GetFilm(int id)
        {
            var film = await _filmService.GetFilmAsync(id);
            return Ok(film);
        }

        [HttpGet("getFilms")]
        public async Task<IActionResult> GetFilms([FromQuery] GetFilmsFilterDto filter)
        {
            var films = await _filmService.GetFilmsAsync(filter);
            return Ok(films);

        }

        [HttpDelete("deleteFilm"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            await _filmService.DeleteFilmAsync(id);
            return Ok(new { message = "Film deleted" });
        }

        [HttpPut("updateFilm"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFilms(UpdateFilmDto request)
        {
            await _filmService.UpdateFilmAsync(request);
            return Ok(new { message = "Film updated" });
        }
    }
}
