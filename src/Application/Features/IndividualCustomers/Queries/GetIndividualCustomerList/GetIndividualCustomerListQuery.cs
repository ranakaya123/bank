using Bank.Application.Features.IndividualCustomers.Dtos;
using MediatR;

namespace Bank.Application.Features.IndividualCustomers.Queries.GetIndividualCustomerList;

public class GetIndividualCustomerListQuery : IRequest<GetIndividualCustomerListResponseDto>
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}

