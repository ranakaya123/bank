using Bank.Application.Features.IndividualCustomers.Dtos;
using Bank.Application.Features.IndividualCustomers.Rules;
using Bank.Application.Features.IndividualCustomers.Constants;
using Bank.Application.Services.Repositories;
using Bank.Core.CrossCuttingConcerns.Exceptions;
using Bank.Domain.Entities;
using MediatR;

namespace Bank.Application.Features.IndividualCustomers.Commands.UpdateIndividualCustomer;

public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdateIndividualCustomerResponseDto>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _businessRules = businessRules;
    }

    public async Task<UpdateIndividualCustomerResponseDto> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        // Müşterinin var olup olmadığını kontrol et
        await _businessRules.IndividualCustomerShouldExistWhenRequested(request.Id);

        // CustomerNumber ve NationalId duplication kontrolü (kendi ID'si hariç)
        var existingCustomer = await _individualCustomerRepository.GetAsync(x => x.Id == request.Id);
        if (existingCustomer == null)
            throw new BusinessException(IndividualCustomerMessages.IndividualCustomerNotExists);

        // CustomerNumber duplication kontrolü
        var customerWithSameNumber = await _individualCustomerRepository.GetAsync(x => x.CustomerNumber == request.CustomerNumber && x.Id != request.Id);
        if (customerWithSameNumber != null)
            throw new BusinessException(IndividualCustomerMessages.CustomerNumberExists);

        // NationalId duplication kontrolü
        var customerWithSameNationalId = await _individualCustomerRepository.GetAsync(x => x.NationalId == request.NationalId && x.Id != request.Id);
        if (customerWithSameNationalId != null)
            throw new BusinessException(IndividualCustomerMessages.NationalIdExists);

        // Müşteri bilgilerini güncelle
        existingCustomer.CustomerNumber = request.CustomerNumber;
        existingCustomer.FirstName = request.FirstName;
        existingCustomer.LastName = request.LastName;
        existingCustomer.NationalId = request.NationalId;
        existingCustomer.DateOfBirth = request.DateOfBirth;
        existingCustomer.Gender = request.Gender;
        existingCustomer.Email = request.Email;
        existingCustomer.Phone = request.Phone;
        existingCustomer.Address = request.Address;
        existingCustomer.Name = $"{request.FirstName} {request.LastName}";
        existingCustomer.UpdatedDate = DateTime.UtcNow;

        var updatedCustomer = await _individualCustomerRepository.UpdateAsync(existingCustomer);

        return new UpdateIndividualCustomerResponseDto
        {
            Id = updatedCustomer.Id,
            CustomerNumber = updatedCustomer.CustomerNumber,
            FullName = updatedCustomer.FullName,
            Email = updatedCustomer.Email,
            UpdatedDate = updatedCustomer.UpdatedDate ?? DateTime.UtcNow,
            Message = IndividualCustomerMessages.IndividualCustomerUpdated
        };
    }
}
