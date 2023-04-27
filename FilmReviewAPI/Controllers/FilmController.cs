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

        [HttpGet("getFilm")]
        public async Task<IActionResult> GetFilm(int id)
        {
            try
            {
                var film = await _filmService.GetFilmAsync(id);
                return Ok(film);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getFilms")]
        public async Task<IActionResult> GetFilms(int page, int pageSize)
        {
            try
            {
                var films = await _filmService.GetFilmsAsync(page, pageSize);
                return Ok(films);
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpDelete("deleteFilm"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            try
            {
                await _filmService.DeleteFilmAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("updateFilm"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFilms(UpdateFilmDto request)
        {
            try
            {
                await _filmService.UpdateFilmAsync(request);
                return Ok(new { message = "Film updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
