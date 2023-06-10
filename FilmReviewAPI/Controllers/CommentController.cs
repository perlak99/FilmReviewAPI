using FilmReviewAPI.DTOs.Comment;
using FilmReviewAPI.Response;
using FilmReviewAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FilmReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("addComment"), Authorize()]
        public async Task<ActionResult<BaseResponse>> AddComment(AddCommentDto commentDto)
        {
            var userId = int.Parse(User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
            await _commentService.AddCommentAsync(commentDto, userId);
            return Ok(ResponseFactory.CreateSuccessResponse());
        }
    }
}
