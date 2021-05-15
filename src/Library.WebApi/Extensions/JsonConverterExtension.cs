using Library.WebApi.Convertors;
using Microsoft.Extensions.DependencyInjection;

namespace Library.WebApi.Extensions
{
    /// <summary>
    /// 1.2.1 - 4
    /// </summary>
    public static class JsonConverterExtension
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