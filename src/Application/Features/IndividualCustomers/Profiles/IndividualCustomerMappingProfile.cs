using AutoMapper;
using Bank.Application.Features.IndividualCustomers.Dtos;
using Bank.Domain.Entities;

namespace Bank.Application.Features.IndividualCustomers.Profiles;

public class IndividualCustomerMappingProfile : Profile
{
    public IndividualCustomerMappingProfile()
    {
        CreateMap<IndividualCustomer, CreateIndividualCustomerResponseDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

        CreateMap<IndividualCustomer, IndividualCustomerDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

        CreateMap<IndividualCustomer, GetIndividualCustomerByIdResponseDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
    }
}

