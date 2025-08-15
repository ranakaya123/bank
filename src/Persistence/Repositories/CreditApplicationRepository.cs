using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;
using Bank.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Repositories;

public class CreditApplicationRepository : AsyncRepository<CreditApplication, Guid>, ICreditApplicationRepository
{
    public CreditApplicationRepository(BankDbContext context) : base(context)
    {
    }

    public async Task<List<CreditApplication>> GetApplicationsByCustomerAsync(Guid customerId)
    {
        return await Query()
            .Where(x => x.CustomerId == customerId)
            .Include(x => x.CreditType)
            .Include(x => x.SubCreditType)
            .OrderByDescending(x => x.ApplicationDate)
            .ToListAsync();
    }

    public async Task<List<CreditApplication>> GetApplicationsByStatusAsync(ApplicationStatus status)
    {
        return await Query()
            .Where(x => x.Status == status)
            .Include(x => x.Customer)
            .Include(x => x.CreditType)
            .OrderBy(x => x.ApplicationDate)
            .ToListAsync();
    }

    public async Task<CreditApplication?> GetApplicationWithDetailsAsync(Guid id)
    {
        return await Query()
            .Include(x => x.Customer)
            .Include(x => x.CreditType)
            .Include(x => x.SubCreditType)
            .Include(x => x.CreditApprovalHistories.OrderBy(h => h.ProcessDate))
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> HasActiveApplicationAsync(Guid customerId, Guid creditTypeId)
    {
        return await Query()
            .AnyAsync(x => x.CustomerId == customerId && 
                          x.CreditTypeId == creditTypeId && 
                          (x.Status == ApplicationStatus.Draft || 
                           x.Status == ApplicationStatus.Submitted || 
                           x.Status == ApplicationStatus.UnderReview));
    }
}
