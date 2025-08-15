using AutoMapper;
using Bank.Application.Features.CreditApplications.Commands.CreateCreditApplication;
using Bank.Application.Features.CreditApplications.Queries.GetCreditApplicationsByCustomer;
using Bank.Domain.Entities;

namespace Bank.Application.Features.CreditApplications.Profiles;

public class CreditApplicationMappingProfile : Profile
{
    public CreditApplicationMappingProfile()
    {
        // CreateCreditApplicationCommand -> IndividualCreditApplication
        CreateMap<CreateCreditApplicationCommand, IndividualCreditApplication>();
        
        // IndividualCreditApplication -> CreateCreditApplicationResponse
        CreateMap<IndividualCreditApplication, CreateCreditApplicationResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        
        // CorporateCreditApplication -> CreateCreditApplicationResponse
        CreateMap<CorporateCreditApplication, CreateCreditApplicationResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        
        // CreditApplication -> CreditApplicationDto (for GetCreditApplicationsByCustomer)
        CreateMap<CreditApplication, CreditApplicationDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.CreditTypeName, opt => opt.MapFrom(src => src.CreditType.Name))
            .ForMember(dest => dest.ApplicationStatus, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
