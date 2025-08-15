using Bank.Core.Repositories;
using Bank.Domain.Entities;

namespace Bank.Application.Services.Repositories;

public interface ICreditApprovalStepRepository : IAsyncRepository<CreditApprovalStep, Guid>
{
    Task<List<CreditApprovalStep>> GetActiveStepsByCreditTypeAsync(Guid creditTypeId);
    Task<List<CreditApprovalStep>> GetStepsByOrderAsync(Guid creditTypeId);
    Task<CreditApprovalStep?> GetNextStepAsync(Guid creditTypeId, int currentOrder);
}
