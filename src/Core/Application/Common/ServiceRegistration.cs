using Microsoft.Extensions.DependencyInjection;
using Bank.Core.Application.Common.Behaviors;
using MediatR;

namespace Bank.Core.Application.Common;

public static class ServiceRegistration
{
    public static IServiceCollection AddCoreApplication(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}
