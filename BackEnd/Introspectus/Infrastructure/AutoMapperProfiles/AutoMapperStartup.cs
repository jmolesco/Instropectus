using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Introspectus.Api.Infrastructure.AutoMapperProfiles
{
    public static class CacheStartup
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
