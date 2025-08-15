using Bank.Core.Repositories;
using Bank.Domain.Entities;

namespace Bank.Application.Services.Repositories;

public interface ISubCreditTypeRepository : IAsyncRepository<SubCreditType, Guid>
{
    Task<List<SubCreditType>> GetActiveSubTypesByCreditTypeAsync(Guid creditTypeId);
    Task<bool> IsSubTypeNameUniqueForCreditTypeAsync(string name, Guid creditTypeId, Guid? excludeId = null);
}
