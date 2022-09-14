using Microsoft.Extensions.DependencyInjection;

namespace Introspectus.Api.Infrastructure.ApplicationServices
{
    public static class ApplicationServicesStartup
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}