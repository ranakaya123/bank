using Bank.Core.Repositories;
using Bank.Domain.Entities;

namespace Bank.Application.Services.Repositories;

public interface IIndividualCustomerRepository : IAsyncRepository<IndividualCustomer, Guid>
{
}
