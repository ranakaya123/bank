using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Repositories;

public class SubCreditTypeRepository : AsyncRepository<SubCreditType, Guid>, ISubCreditTypeRepository
{
    public SubCreditTypeRepository(BankDbContext context) : base(context)
    {
    }

    public async Task<List<SubCreditType>> GetActiveSubTypesByCreditTypeAsync(Guid creditTypeId)
    {
        return await Query()
            .Where(x => x.CreditTypeId == creditTypeId && x.IsActive)
            .ToListAsync();
    }

    public async Task<bool> IsSubTypeNameUniqueForCreditTypeAsync(string name, Guid creditTypeId, Guid? excludeId = null)
    {
        var query = Query().Where(x => x.Name == name && x.CreditTypeId == creditTypeId);
        
        if (excludeId.HasValue)
            query = query.Where(x => x.Id != excludeId.Value);
            
        return !await query.AnyAsync();
    }
}
