using Bank.Application.Services.Repositories;
using Bank.Domain.Entities;
using Bank.Core.Repositories;
using Bank.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Repositories;

public class ApplicationUserRepository : AsyncRepository<ApplicationUser, Guid>, IApplicationUserRepository
{
    public ApplicationUserRepository(BankDbContext context) : base(context)
    {
    }

    public async Task<ApplicationUser?> GetByEmailAsync(string email)
    {
        return await Query()
            .Include(x => x.User)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Customer.Email == email);
    }

    public async Task<ApplicationUser?> GetByCustomerNumberAsync(string customerNumber)
    {
        return await Query()
            .Include(x => x.User)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Customer.CustomerNumber == customerNumber);
    }

    public async Task<ApplicationUser?> GetByUserIdAsync(int userId)
    {
        return await Query()
            .Include(x => x.User)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<ApplicationUser?> GetIndividualCustomerWithDetailsAsync(Guid id)
    {
        return await Query()
            .Include(x => x.User)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id && x.CustomerType == "Individual");
    }

    public async Task<ApplicationUser?> GetCorporateCustomerWithDetailsAsync(Guid id)
    {
        return await Query()
            .Include(x => x.User)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id && x.CustomerType == "Corporate");
    }

    public async Task<List<ApplicationUser>> GetActiveUsersAsync()
    {
        return await Query()
            .Include(x => x.User)
            .Include(x => x.Customer)
            .Where(x => x.Customer.IsActive)
            .ToListAsync();
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        return !await Query().AnyAsync(x => x.Customer.Email == email);
    }

    public async Task<bool> IsCustomerNumberUniqueAsync(string customerNumber)
    {
        return !await Query().AnyAsync(x => x.Customer.CustomerNumber == customerNumber);
    }
}
