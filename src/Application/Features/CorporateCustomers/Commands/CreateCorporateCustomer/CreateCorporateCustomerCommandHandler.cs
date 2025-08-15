using Bank.Application.Features.CorporateCustomers.Dtos;
using Bank.Application.Features.CorporateCustomers.Rules;
using Bank.Application.Services.Repositories;
using Bank.Domain.Entities;
using MediatR;

namespace Bank.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;

public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreateCorporateCustomerResponseDto>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;
    private readonly CorporateCustomerBusinessRules _businessRules;

    public CreateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, CorporateCustomerBusinessRules businessRules)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
        _businessRules = businessRules;
    }

    public async Task<CreateCorporateCustomerResponseDto> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.CustomerNumberCanNotBeDuplicatedWhenInserted(request.CustomerNumber);
        await _businessRules.TaxNumberCanNotBeDuplicatedWhenInserted(request.TaxNumber);

        var corporateCustomer = new CorporateCustomer
        {
            CustomerNumber = request.CustomerNumber,
            CompanyName = request.CompanyName,
            TaxNumber = request.TaxNumber,
            TradeRegistryNumber = request.TradeRegistryNumber,
            ContactPerson = request.ContactPerson,
            ContactPersonPhone = request.ContactPersonPhone,
            ContactPersonEmail = request.ContactPersonEmail,
            Sector = request.Sector,
            EstablishmentDate = request.EstablishmentDate,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address,
            Name = request.CompanyName
        };

        var createdCustomer = await _corporateCustomerRepository.AddAsync(corporateCustomer);

        return new CreateCorporateCustomerResponseDto
        {
            Id = createdCustomer.Id,
            CustomerNumber = createdCustomer.CustomerNumber,
            CompanyName = createdCustomer.CompanyName,
            TaxNumber = createdCustomer.TaxNumber,
            Email = createdCustomer.Email,
            CreatedDate = createdCustomer.CreatedDate
        };
    }
}

