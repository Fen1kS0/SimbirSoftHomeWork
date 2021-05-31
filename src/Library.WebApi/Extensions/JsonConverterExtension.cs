using Library.WebApi.Convertors;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

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
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                
                options.SerializerSettings.Converters.Add(new DateTimeOffsetJsonConverter());
                options.SerializerSettings.Converters.Add(new DateTimeJsonConverter());
            });

            return services;
        }
    }
}