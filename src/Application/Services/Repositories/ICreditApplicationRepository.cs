using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;

namespace Bank.Application.Services.Repositories;

public interface ICreditApplicationRepository : IAsyncRepository<CreditApplication, Guid>
{
    Task<List<CreditApplication>> GetApplicationsByCustomerAsync(Guid customerId);
    Task<List<CreditApplication>> GetApplicationsByStatusAsync(ApplicationStatus status);
    Task<CreditApplication?> GetApplicationWithDetailsAsync(Guid id);
    Task<bool> HasActiveApplicationAsync(Guid customerId, Guid creditTypeId);
}
