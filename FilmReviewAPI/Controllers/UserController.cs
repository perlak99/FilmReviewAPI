using FilmReviewAPI.DTOs.Auth;
using FilmReviewAPI.Services.Interfaces;
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
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto request)
        {
            var user = await _authService.RegisterUserAsync(request.Username, request.Password);
            return Ok(new { message = "Registration successful" });
        }

        [HttpPost("grantRole"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GrantRole(int userId, int roleId)
        {
            await _authService.GrantRole(userId, roleId);
            return Ok(new { message = "Role granted" });
        }
    }
}
