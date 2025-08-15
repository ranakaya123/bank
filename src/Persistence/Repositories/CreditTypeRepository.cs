using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Bank.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Repositories;

public class CreditTypeRepository : AsyncRepository<CreditType, Guid>, ICreditTypeRepository
{
    public CreditTypeRepository(BankDbContext context) : base(context)
    {
    }

    public async Task<List<CreditType>> GetActiveCreditTypesByCategoryAsync(CreditCategory category)
    {
        return await Query()
            .Where(x => x.Category == category && x.IsActive)
            .ToListAsync();
    }

    public async Task<CreditType?> GetCreditTypeWithSubTypesAsync(Guid id)
    {
        return await Query()
            .Include(x => x.SubCreditTypes.Where(st => st.IsActive))
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> IsCreditTypeNameUniqueAsync(string name, Guid? excludeId = null)
    {
        var query = Query().Where(x => x.Name == name);
        
        if (excludeId.HasValue)
            query = query.Where(x => x.Id != excludeId.Value);
            
        return !await query.AnyAsync();
    }
}
