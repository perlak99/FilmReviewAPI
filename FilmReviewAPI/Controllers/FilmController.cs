using FilmReviewAPI.DTOs.Film;
using FilmReviewAPI.Response;
using FilmReviewAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<ActionResult<BaseResponse>> AddFilm (AddFilmDto filmDto)
        {
            var userId = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
            await _filmService.AddFilmAsync(filmDto, userId);
            return Ok(ResponseFactory.CreateSuccessResponse());
        }

        [HttpGet("getFilm")]
        public async Task<ActionResult<DataResponse<GetFilmDto>>> GetFilm(int id)
        {
            var film = await _filmService.GetFilmAsync(id);
            return Ok(ResponseFactory.CreateSuccessResponse(film));
        }

        [HttpGet("getFilms")]
        public async Task<ActionResult<DataResponse<List<GetFilmListDto>>>> GetFilms([FromQuery] FilmsFilterDto filter)
        {
            var films = await _filmService.GetFilmsAsync(filter);
            return Ok(ResponseFactory.CreateSuccessResponse(films));
        }

        [HttpDelete("deleteFilm"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> DeleteFilm(int id)
        {
            await _filmService.DeleteFilmAsync(id);
            return Ok(ResponseFactory.CreateSuccessResponse());
        }

        [HttpPut("updateFilm"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> UpdateFilms(UpdateFilmDto request)
        {
            await _filmService.UpdateFilmAsync(request);
            return Ok(ResponseFactory.CreateSuccessResponse());
        }
    }
}
