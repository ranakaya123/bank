using Bank.Application.Features.IndividualCustomers.Constants;
using Bank.Application.Services.Repositories;
using Bank.Core.CrossCuttingConcerns.Exceptions;
using Bank.Domain.Entities;

namespace Bank.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;
    private readonly IApplicationUserRepository _applicationUserRepository;
    private readonly IUserRepository _userRepository;

    public IndividualCustomerBusinessRules(
        IIndividualCustomerRepository individualCustomerRepository,
        IApplicationUserRepository applicationUserRepository,
        IUserRepository userRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
        _applicationUserRepository = applicationUserRepository;
        _userRepository = userRepository;
    }

    public async Task CustomerNumberCanNotBeDuplicatedWhenInserted(string customerNumber)
    {
        var result = await _individualCustomerRepository.GetAsync(x => x.CustomerNumber == customerNumber);
        if (result != null) throw new BusinessException(IndividualCustomerMessages.CustomerNumberExists);
    }

    public async Task NationalIdCanNotBeDuplicatedWhenInserted(string nationalId)
    {
        var result = await _individualCustomerRepository.GetAsync(x => x.NationalId == nationalId);
        if (result != null) throw new BusinessException(IndividualCustomerMessages.NationalIdExists);
    }

    public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
    {
        var result = await _applicationUserRepository.GetByEmailAsync(email);
        if (result != null) throw new BusinessException(IndividualCustomerMessages.EmailExists);
    }

    public async Task UsernameCanNotBeDuplicatedWhenInserted(string username)
    {
        var result = await _userRepository.GetByUsernameAsync(username);
        if (result != null) throw new BusinessException(IndividualCustomerMessages.UsernameExists);
    }

    public async Task IndividualCustomerShouldExistWhenRequested(Guid id)
    {
        var result = await _individualCustomerRepository.GetAsync(x => x.Id == id);
        if (result == null) throw new BusinessException(IndividualCustomerMessages.IndividualCustomerNotExists);
    }

    public Task IndividualCustomerShouldExistWhenRequested(IndividualCustomer? individualCustomer)
    {
        if (individualCustomer == null)
            throw new BusinessException(IndividualCustomerMessages.IndividualCustomerNotExists);
        
        return Task.CompletedTask;
    }
}

