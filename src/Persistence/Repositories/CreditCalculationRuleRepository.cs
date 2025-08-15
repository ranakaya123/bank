using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Bank.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Repositories;

public class CreditCalculationRuleRepository : AsyncRepository<CreditCalculationRule, Guid>, ICreditCalculationRuleRepository
{
    public CreditCalculationRuleRepository(BankDbContext context) : base(context)
    {
    }

    public async Task<List<CreditCalculationRule>> GetActiveRulesByCreditTypeAsync(Guid creditTypeId)
    {
        return await Query()
            .Where(x => x.CreditTypeId == creditTypeId && x.IsActive)
            .OrderBy(x => x.Priority)
            .ToListAsync();
    }

    public async Task<List<CreditCalculationRule>> GetRulesByTypeAsync(Guid creditTypeId, RuleType ruleType)
    {
        return await Query()
            .Where(x => x.CreditTypeId == creditTypeId && x.Type == ruleType && x.IsActive)
            .OrderBy(x => x.Priority)
            .ToListAsync();
    }

    public async Task<List<CreditCalculationRule>> GetRulesByPriorityAsync(Guid creditTypeId)
    {
        return await Query()
            .Where(x => x.CreditTypeId == creditTypeId && x.IsActive)
            .OrderBy(x => x.Priority)
            .ToListAsync();
    }
}
