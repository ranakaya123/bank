using MediatR;
using Bank.Core.Application.Common;

namespace Bank.Application.Features.CreditTypes.Queries.GetCreditTypeById;

public class GetCreditTypeByIdQuery : IRequest<GetCreditTypeByIdResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { "Customer", "BankEmployee", "Admin" };
}
