using Microsoft.Extensions.DependencyInjection;
using Bank.Core.Application.Common;
using Bank.Core.Security;

namespace Bank.Core;

public static class ServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddCoreApplication();
        services.AddCoreSecurity();
        
        return services;
    }
}
