using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Persistence.Contexts;

namespace Bank.Persistence.Repositories;

public class CorporateCustomerRepository : AsyncRepository<CorporateCustomer, Guid>, ICorporateCustomerRepository
{
    public CorporateCustomerRepository(BankDbContext context) : base(context)
    {
    }
}
