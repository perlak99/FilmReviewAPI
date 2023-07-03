using FilmReviewAPI.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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
            catch (ValidationException ex)
            {
                await WriteErrorDetailsAsync(httpContext, ex.Message, (int)HttpStatusCode.BadRequest);
            }
            catch (ArgumentException ex)
            {
                await WriteErrorDetailsAsync(httpContext, ex.Message, (int)HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                await WriteErrorDetailsAsync(httpContext, "Internal server error", (int)HttpStatusCode.InternalServerError);
            }
        }

        private async Task WriteErrorDetailsAsync(HttpContext context, string message, int statusCode, string contentType = "application/json")
        {
            var error = ResponseFactory.CreateErrorResponse(statusCode, message);
            context.Response.ContentType = contentType;
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }

        public static async Task WriteUnauthorizedErrorDetailsAsync(JwtBearerChallengeContext context)
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.Headers.Append("content-type", "application/json");
            await context.Response.WriteAsync(JsonConvert.SerializeObject(ResponseFactory.CreateErrorResponse(401, "You are not authorized! Please log in or register.")));
        }
    }
}
