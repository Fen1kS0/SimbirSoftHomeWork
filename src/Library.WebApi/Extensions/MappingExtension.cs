using Library.Core.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Library.WebApi.Extensions
{
    public static class MappingExtension
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AuthorProfile));
            services.AddAutoMapper(typeof(BookProfile));
            services.AddAutoMapper(typeof(GenreProfile));
            services.AddAutoMapper(typeof(PersonProfile));
            
            return services;
        }
    }
}