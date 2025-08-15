using Bank.Core.Security.Entity;
using Bank.Core.Repositories;

namespace Bank.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, int>
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> IsUsernameUniqueAsync(string username);
    Task<bool> IsEmailUniqueAsync(string email);
}
