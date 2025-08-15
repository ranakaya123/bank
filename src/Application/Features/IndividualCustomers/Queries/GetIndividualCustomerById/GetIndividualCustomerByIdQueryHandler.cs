using Bank.Application.Features.IndividualCustomers.Dtos;
using Bank.Application.Features.IndividualCustomers.Rules;
using Bank.Application.Services.Repositories;
using Bank.Domain.Entities;
using MediatR;

namespace Bank.Application.Features.IndividualCustomers.Queries.GetIndividualCustomerById;

public class GetIndividualCustomerByIdQueryHandler : IRequestHandler<GetIndividualCustomerByIdQuery, GetIndividualCustomerByIdResponseDto>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public GetIndividualCustomerByIdQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _businessRules = businessRules;
    }

    public async Task<GetIndividualCustomerByIdResponseDto> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var individualCustomer = await _individualCustomerRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        
        await _businessRules.IndividualCustomerShouldExistWhenRequested(individualCustomer);

        var response = new GetIndividualCustomerByIdResponseDto
        {
            Id = individualCustomer!.Id,
            CustomerNumber = individualCustomer.CustomerNumber,
            FirstName = individualCustomer.FirstName,
            LastName = individualCustomer.LastName,
            FullName = individualCustomer.FullName,
            NationalId = individualCustomer.NationalId,
            DateOfBirth = individualCustomer.DateOfBirth,
            Gender = individualCustomer.Gender,
            Email = individualCustomer.Email,
            Phone = individualCustomer.Phone,
            Address = individualCustomer.Address,
            IsActive = individualCustomer.IsActive,
            RegistrationDate = individualCustomer.RegistrationDate,
            CreatedDate = individualCustomer.CreatedDate,
            UpdatedDate = individualCustomer.UpdatedDate
        };

        return response;
    }
}
