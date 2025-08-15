using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bank.Application.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Add MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        // Add AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        // Add Business Rules
        services.AddScoped<Features.IndividualCustomers.Rules.IndividualCustomerBusinessRules>();
        services.AddScoped<Features.CorporateCustomers.Rules.CorporateCustomerBusinessRules>();
        
        return services;
    }
}
