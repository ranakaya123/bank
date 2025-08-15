using Bank.Application.Features.IndividualCustomers.Dtos;
using Bank.Application.Features.IndividualCustomers.Rules;
using Bank.Application.Features.IndividualCustomers.Constants;
using Bank.Application.Services.Repositories;
using Bank.Core.CrossCuttingConcerns.Exceptions;
using MediatR;

namespace Bank.Application.Features.IndividualCustomers.Commands.DeleteIndividualCustomer;

public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeleteIndividualCustomerResponseDto>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _businessRules = businessRules;
    }

    public async Task<DeleteIndividualCustomerResponseDto> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        // Müşterinin var olup olmadığını kontrol et
        await _businessRules.IndividualCustomerShouldExistWhenRequested(request.Id);
     
        // Müşteriyi sil (soft delete)
        await _individualCustomerRepository.DeleteAsync(request.Id);

        return new DeleteIndividualCustomerResponseDto
        {
            Id = request.Id,
            Message = IndividualCustomerMessages.IndividualCustomerDeleted
        };
    }
}
