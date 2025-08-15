using MediatR;
using Bank.Core.Application.Common;

namespace Bank.Application.Features.CreditTypes.Queries.GetCreditTypeList;

public class GetCreditTypeListQuery : IRequest<GetCreditTypeListResponse>, ISecuredRequest
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
    public string? Category { get; set; }
    public bool? IsActive { get; set; }

    public string[] Roles => new[] { "Customer", "BankEmployee", "Admin" };
}
