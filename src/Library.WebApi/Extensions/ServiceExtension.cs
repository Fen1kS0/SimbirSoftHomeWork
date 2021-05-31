using Library.Core.Interfaces.Services;
using Library.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IFindAuthorsService, FindAuthorsService>();

            return services;
        }
    }
}