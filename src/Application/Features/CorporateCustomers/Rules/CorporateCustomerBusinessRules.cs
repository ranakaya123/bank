using Bank.Application.Features.CorporateCustomers.Constants;
using Bank.Application.Services.Repositories;
using Bank.Core.CrossCuttingConcerns.Exceptions;

namespace Bank.Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task CustomerNumberCanNotBeDuplicatedWhenInserted(string customerNumber)
    {
        var result = await _corporateCustomerRepository.GetAsync(x => x.CustomerNumber == customerNumber);
        if (result != null) throw new BusinessException(CorporateCustomerMessages.CustomerNumberExists);
    }

    public async Task TaxNumberCanNotBeDuplicatedWhenInserted(string taxNumber)
    {
        var result = await _corporateCustomerRepository.GetAsync(x => x.TaxNumber == taxNumber);
        if (result != null) throw new BusinessException(CorporateCustomerMessages.TaxNumberExists);
    }

    public async Task CorporateCustomerShouldExistWhenRequested(Guid id)
    {
        var result = await _corporateCustomerRepository.GetAsync(x => x.Id == id);
        if (result == null) throw new BusinessException(CorporateCustomerMessages.CorporateCustomerNotExists);
    }
}

