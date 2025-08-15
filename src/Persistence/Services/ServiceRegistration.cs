using Bank.Application.Services.Repositories;
using Bank.Persistence.Contexts;
using Bank.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Persistence.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<BankDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        // Add Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
        services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();
        
        // Credit System Repositories
        services.AddScoped<ICreditTypeRepository, CreditTypeRepository>();
        services.AddScoped<ISubCreditTypeRepository, SubCreditTypeRepository>();
        services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();
        services.AddScoped<ICreditCalculationRuleRepository, CreditCalculationRuleRepository>();
        services.AddScoped<ICreditApprovalStepRepository, CreditApprovalStepRepository>();
        services.AddScoped<ICreditApprovalHistoryRepository, CreditApprovalHistoryRepository>();
        
        return services;
    }
}
