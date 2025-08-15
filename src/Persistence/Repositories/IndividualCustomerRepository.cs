using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using Bank.Domain.Entities;
using Bank.Persistence.Contexts;

namespace Bank.Persistence.Repositories;

public class IndividualCustomerRepository : AsyncRepository<IndividualCustomer, Guid>, IIndividualCustomerRepository
{
    public IndividualCustomerRepository(BankDbContext context) : base(context)
    {
    }
}
