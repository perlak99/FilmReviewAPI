using FilmReviewAPI.DTOs.Director;
using FilmReviewAPI.Response;
using FilmReviewAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost("addDirector")]
        public async Task<ActionResult<BaseResponse>> AddDirector(AddDirectorDto request)
        {
            var userId = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
            await _directorService.AddDirector(request, userId);
            return Ok(ResponseFactory.CreateSuccessResponse());
        }

        [HttpPut("changeDirectorStatus"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<BaseResponse>> ChangeDirectorStatus(int directorId, int statusId)
        {
            await _directorService.ChangeDirectorStatus(directorId, statusId);
            return Ok(ResponseFactory.CreateSuccessResponse());
        }
    }
}
