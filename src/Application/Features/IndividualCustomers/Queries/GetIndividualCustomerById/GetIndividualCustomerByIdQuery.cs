using Bank.Application.Features.IndividualCustomers.Dtos;
using MediatR;

namespace Bank.Application.Features.IndividualCustomers.Queries.GetIndividualCustomerById;

public class GetIndividualCustomerByIdQuery : IRequest<GetIndividualCustomerByIdResponseDto>
{
    public Guid Id { get; set; }
}
