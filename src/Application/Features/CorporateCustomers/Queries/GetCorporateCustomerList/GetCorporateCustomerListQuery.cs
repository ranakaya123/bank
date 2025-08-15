using Bank.Application.Features.CorporateCustomers.Dtos;
using MediatR;

namespace Bank.Application.Features.CorporateCustomers.Queries.GetCorporateCustomerList;

public class GetCorporateCustomerListQuery : IRequest<GetCorporateCustomerListResponseDto>
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}

