using System;
using System.Threading.Tasks;
using Library.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Library.WebApi.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);    
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;

                await HandleResponse(context, e);
            }
            catch (BadRequestException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await HandleResponse(context, e);
            }
        }

        private async Task HandleResponse(HttpContext context, Exception e)
        {
            string jsonString = JsonSerializer.Serialize(new
            {
                Error = e.Message
            });
            
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(jsonString);
            
            _logger.LogError(e.Message);
        }
    }
}