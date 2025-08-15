using Bank.Application.Services.Repositories;
using Bank.Core.Security.Entity;
using Bank.Core.Repositories;
using Bank.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Repositories;

public class UserRepository : AsyncRepository<User, int>, IUserRepository
{
    public UserRepository(BankDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await Query().FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Query().FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<bool> IsUsernameUniqueAsync(string username)
    {
        return !await Query().AnyAsync(x => x.Username == username);
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        return !await Query().AnyAsync(x => x.Email == email);
    }
}
