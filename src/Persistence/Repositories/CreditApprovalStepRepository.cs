using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Repositories;

public class CreditApprovalStepRepository : AsyncRepository<CreditApprovalStep, Guid>, ICreditApprovalStepRepository
{
    public CreditApprovalStepRepository(BankDbContext context) : base(context)
    {
    }

    public async Task<List<CreditApprovalStep>> GetActiveStepsByCreditTypeAsync(Guid creditTypeId)
    {
        return await Query()
            .Where(x => x.CreditTypeId == creditTypeId && x.IsActive)
            .OrderBy(x => x.Order)
            .ToListAsync();
    }

    public async Task<List<CreditApprovalStep>> GetStepsByOrderAsync(Guid creditTypeId)
    {
        return await Query()
            .Where(x => x.CreditTypeId == creditTypeId && x.IsActive)
            .OrderBy(x => x.Order)
            .ToListAsync();
    }

    public async Task<CreditApprovalStep?> GetNextStepAsync(Guid creditTypeId, int currentOrder)
    {
        return await Query()
            .Where(x => x.CreditTypeId == creditTypeId && x.Order > currentOrder && x.IsActive)
            .OrderBy(x => x.Order)
            .FirstOrDefaultAsync();
    }
}
