using Library.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Library.WebApi.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}