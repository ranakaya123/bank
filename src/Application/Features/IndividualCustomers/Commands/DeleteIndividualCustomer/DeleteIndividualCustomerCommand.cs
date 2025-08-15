using MediatR;
using Bank.Application.Features.IndividualCustomers.Dtos;

namespace Bank.Application.Features.IndividualCustomers.Commands.DeleteIndividualCustomer;

public class DeleteIndividualCustomerCommand : IRequest<DeleteIndividualCustomerResponseDto>
{
    public Guid Id { get; set; }
}
