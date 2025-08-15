using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Persistence.Contexts;

namespace Bank.Persistence.Repositories;

public class CustomerRepository : AsyncRepository<Customer, Guid>, ICustomerRepository
{
    public CustomerRepository(BankDbContext context) : base(context)
    {
    }
}
