using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Bank.Core.Security.JWT;
using Bank.Core.Security.Extensions;

namespace Bank.Core.Security;

public static class ServiceRegistration
{
    public static IServiceCollection AddCoreSecurity(this IServiceCollection services)
    {
        services.AddScoped<IJwtHelper, JwtHelper>();
        
        return services;
    }
    
    public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSecurityServices(configuration);
        services.AddCorsPolicy(configuration);
        services.AddRateLimiting();
        
        return services;
    }
}
