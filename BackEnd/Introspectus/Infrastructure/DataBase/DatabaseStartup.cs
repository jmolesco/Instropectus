using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Introspectus.Api.Infrastructure.Database
{
    public static class DatabaseStartup
    {
        public static IServiceCollection ConfigureDatabaseSqlServer(this IServiceCollection services, IConfiguration Configuration)
        {           
            return services;
        }
    }
}