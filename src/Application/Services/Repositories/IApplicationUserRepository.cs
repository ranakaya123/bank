using Bank.Domain.Entities;
using Bank.Core.Repositories;

namespace Bank.Application.Services.Repositories;

public interface IApplicationUserRepository : IAsyncRepository<ApplicationUser, Guid>
{
    Task<ApplicationUser?> GetByEmailAsync(string email);
    Task<ApplicationUser?> GetByCustomerNumberAsync(string customerNumber);
    Task<ApplicationUser?> GetByUserIdAsync(int userId);
    Task<ApplicationUser?> GetIndividualCustomerWithDetailsAsync(Guid id);
    Task<ApplicationUser?> GetCorporateCustomerWithDetailsAsync(Guid id);
    Task<List<ApplicationUser>> GetActiveUsersAsync();
    Task<bool> IsEmailUniqueAsync(string email);
    Task<bool> IsCustomerNumberUniqueAsync(string customerNumber);
}
