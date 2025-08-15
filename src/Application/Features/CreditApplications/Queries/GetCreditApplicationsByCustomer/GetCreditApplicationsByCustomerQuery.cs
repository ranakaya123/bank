using MediatR;
using Bank.Core.Application.Common;

namespace Bank.Application.Features.CreditApplications.Queries.GetCreditApplicationsByCustomer;

public class GetCreditApplicationsByCustomerQuery : IRequest<GetCreditApplicationsByCustomerResponse>, ISecuredRequest
{
    public Guid CustomerId { get; set; }

    public string[] Roles => new[] { "Customer", "BankEmployee", "Admin" };
}
