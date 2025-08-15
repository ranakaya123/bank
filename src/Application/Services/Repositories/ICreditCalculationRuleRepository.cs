using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;

namespace Bank.Application.Services.Repositories;

public interface ICreditCalculationRuleRepository : IAsyncRepository<CreditCalculationRule, Guid>
{
    Task<List<CreditCalculationRule>> GetActiveRulesByCreditTypeAsync(Guid creditTypeId);
    Task<List<CreditCalculationRule>> GetRulesByTypeAsync(Guid creditTypeId, RuleType ruleType);
    Task<List<CreditCalculationRule>> GetRulesByPriorityAsync(Guid creditTypeId);
}
