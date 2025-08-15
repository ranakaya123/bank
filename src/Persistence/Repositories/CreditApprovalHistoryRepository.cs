using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Bank.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Repositories;

public class CreditApprovalHistoryRepository : AsyncRepository<CreditApprovalHistory, Guid>, ICreditApprovalHistoryRepository
{
    public CreditApprovalHistoryRepository(BankDbContext context) : base(context)
    {
    }

    public async Task<List<CreditApprovalHistory>> GetHistoryByApplicationAsync(Guid applicationId)
    {
        return await Query()
            .Where(x => x.CreditApplicationId == applicationId)
            .Include(x => x.CreditApprovalStep)
            .OrderBy(x => x.ProcessDate)
            .ToListAsync();
    }

    public async Task<List<CreditApprovalHistory>> GetHistoryByStatusAsync(ApprovalStatus status)
    {
        return await Query()
            .Where(x => x.Status == status)
            .Include(x => x.CreditApplication)
            .Include(x => x.CreditApprovalStep)
            .OrderByDescending(x => x.ProcessDate)
            .ToListAsync();
    }

    public async Task<CreditApprovalHistory?> GetLastHistoryByApplicationAsync(Guid applicationId)
    {
        return await Query()
            .Where(x => x.CreditApplicationId == applicationId)
            .Include(x => x.CreditApprovalStep)
            .OrderByDescending(x => x.ProcessDate)
            .FirstOrDefaultAsync();
    }
}
