using Bank.Core.Repositories;
using Bank.Domain.Entities;

namespace Bank.Application.Services.Repositories;

public interface ICustomerRepository : IAsyncRepository<Customer, Guid>
{
}
