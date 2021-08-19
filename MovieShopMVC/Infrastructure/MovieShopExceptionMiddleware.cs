using ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieShopMVC.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;


        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Exception Middleware Beginning");

            try
            {
                // when everything is good.
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // when any exception happens then handle here
                // MovieService => exception
                _logger.LogError($"Catching the exception in Middleware {ex}");

                await HandleException(httpContext, ex);
            }
            //return _next(httpContext);
        }

        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            // catch the actual type of exception, set the http status code,
            // log the details of the exception
            // URL, Controller/Action, DateTime, StackTrace, Error Message, UserId (if user is authenticated), IP Address using SeriLog
            // Log the exception using SeriLog Text or JSON files...

            // Send email using MailKit to Dev Team
            // Display a friendly page to User
            // 200 OK, 201 Created, 400 Bad request
            // 401 UnAuthorized, 403 Forbidden, 404 Not Found, 500 Internal Server Error
            switch (ex)
            {
                case ConflictException _:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case DllNotFoundException _:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            httpContext.Response.Redirect("/Home/Error");

            await Task.CompletedTask;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
