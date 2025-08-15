using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;

namespace Bank.Application.Services.Repositories;

public interface ICreditApprovalHistoryRepository : IAsyncRepository<CreditApprovalHistory, Guid>
{
    Task<List<CreditApprovalHistory>> GetHistoryByApplicationAsync(Guid applicationId);
    Task<List<CreditApprovalHistory>> GetHistoryByStatusAsync(ApprovalStatus status);
    Task<CreditApprovalHistory?> GetLastHistoryByApplicationAsync(Guid applicationId);
}
