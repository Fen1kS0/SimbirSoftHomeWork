using BookShop.WebApi.Convertors;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.WebApi.Extensions
{
    /// <summary>
    /// 1.2.1 - 4
    /// </summary>
    public static class JsonConverterExtensions
    {
        /// <summary>
        /// 1.2.1 - 4
        /// </summary>
        public static IServiceCollection AddJsonConverters(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeOffsetJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
            });

            return services;
        }
    }
}