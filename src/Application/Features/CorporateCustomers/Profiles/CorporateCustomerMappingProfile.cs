using AutoMapper;
using Bank.Application.Features.CorporateCustomers.Dtos;
using Bank.Domain.Entities;

namespace Bank.Application.Features.CorporateCustomers.Profiles;

public class CorporateCustomerMappingProfile : Profile
{
    public CorporateCustomerMappingProfile()
    {
        CreateMap<CorporateCustomer, CreateCorporateCustomerResponseDto>();
        CreateMap<CorporateCustomer, CorporateCustomerDto>();
    }
}

