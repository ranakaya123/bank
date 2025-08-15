using Bank.Application.Features.IndividualCustomers.Dtos;
using Bank.Application.Features.IndividualCustomers.Rules;
using Bank.Application.Services.Repositories;
using Bank.Domain.Entities;
using Bank.Core.Security.Entity;
using Bank.Core.Security.Encryption;
using MediatR;

namespace Bank.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;

public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerResponseDto>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IUserRepository _userRepository;
    private readonly IApplicationUserRepository _applicationUserRepository;
    private readonly IndividualCustomerBusinessRules _businessRules;

    public CreateIndividualCustomerCommandHandler(
        IIndividualCustomerRepository individualCustomerRepository,
        IUserRepository userRepository,
        IApplicationUserRepository applicationUserRepository,
        IndividualCustomerBusinessRules businessRules)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _userRepository = userRepository;
        _applicationUserRepository = applicationUserRepository;
        _businessRules = businessRules;
    }

    public async Task<CreateIndividualCustomerResponseDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.CustomerNumberCanNotBeDuplicatedWhenInserted(request.CustomerNumber);
        await _businessRules.NationalIdCanNotBeDuplicatedWhenInserted(request.NationalId);
        await _businessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);
        await _businessRules.UsernameCanNotBeDuplicatedWhenInserted(request.Username);

        // 1. IndividualCustomer oluştur
        var individualCustomer = new IndividualCustomer
        {
            CustomerNumber = request.CustomerNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            NationalId = request.NationalId,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address,
            Name = $"{request.FirstName} {request.LastName}"
        };

        var createdCustomer = await _individualCustomerRepository.AddAsync(individualCustomer);

        // 2. User oluştur (sistem girişi için)
        var passwordSalt = Guid.NewGuid().ToString();
        var passwordHash = EncryptionHelper.HashPassword(request.Password + passwordSalt);

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            IsActive = true
        };

        var createdUser = await _userRepository.AddAsync(user);

        // 3. ApplicationUser oluştur (User ve Customer arasında bağlantı)
        var applicationUser = new ApplicationUser
        {
            UserId = createdUser.Id,
            CustomerId = createdCustomer.Id,
            CustomerType = "Individual"
        };

        var createdApplicationUser = await _applicationUserRepository.AddAsync(applicationUser);

        return new CreateIndividualCustomerResponseDto
        {
            Id = createdCustomer.Id,
            CustomerNumber = createdCustomer.CustomerNumber,
            FullName = createdCustomer.FullName,
            Email = createdCustomer.Email,
            Username = createdUser.Username,
            CreatedDate = createdCustomer.CreatedDate
        };
    }
}

