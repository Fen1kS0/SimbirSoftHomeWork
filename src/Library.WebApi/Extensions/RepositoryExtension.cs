using Library.Core.Interfaces.Repositories;
using Library.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Library.WebApi.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}