using FilmReviewAPI.DTOs;
using FilmReviewAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateDto request)
        {
            var token = await _authService.AuthenticateUserAsync(request.Username, request.Password);

            if (token == null)
            {
                return BadRequest(new { message = "Invalid username or password" });
            }

            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto request)
        {
            try
            {
                var user = await _authService.RegisterUserAsync(request.Username, request.Password);
                return Ok(new { message = "Registration successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("testEndPoint")]
        [Authorize]
        public async Task<IActionResult> TestEndPoint()
        {
            return Ok(new { message = "hello" });
        }

    }
}
