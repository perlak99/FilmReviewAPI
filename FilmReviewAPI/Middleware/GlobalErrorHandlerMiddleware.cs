using FilmReviewAPI.DTOs;
using Newtonsoft.Json;
using System.Net;

namespace FilmReviewAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ArgumentException ex)
            {
                await HandleArgumentExceptionAsync(httpContext, ex);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(httpContext);
            }
        }

        private async Task WriteErrorDetailsAsync(HttpContext context, string message)
        {
            var error = new ErrorDetails(context.Response.StatusCode, message);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }

        private async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await WriteErrorDetailsAsync(context, "Internal server error");
        }

        private async Task HandleArgumentExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await WriteErrorDetailsAsync(context, exception.Message);
        }
    }
}
