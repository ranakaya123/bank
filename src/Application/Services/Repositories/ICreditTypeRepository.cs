using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;

namespace Bank.Application.Services.Repositories;

public interface ICreditTypeRepository : IAsyncRepository<CreditType, Guid>
{
    Task<List<CreditType>> GetActiveCreditTypesByCategoryAsync(CreditCategory category);
    Task<CreditType?> GetCreditTypeWithSubTypesAsync(Guid id);
    Task<bool> IsCreditTypeNameUniqueAsync(string name, Guid? excludeId = null);
}
