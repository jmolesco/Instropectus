using Introspectus.Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Introspectus.Api.Repository
{
    public static class MobileSpeedCameraRepositoryDI
    {
        public static IServiceCollection AddMobileSpeedCameraRepositoryDI(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IMobileSpeedCameraRepository, MobileSpeedCameraRepository>();
            return services;
        }
    }
}
