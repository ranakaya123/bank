using AutoMapper;
using Bank.Application.Features.CreditTypes.Commands.CreateCreditType;
using Bank.Application.Features.CreditTypes.Queries.GetCreditTypeList;
using Bank.Application.Features.CreditTypes.Queries.GetCreditTypeById;
using Bank.Domain.Entities;
using Bank.Domain.Enums;

namespace Bank.Application.Features.CreditTypes.Profiles;

public class CreditTypeMappingProfile : Profile
{
    public CreditTypeMappingProfile()
    {
        // CreateCreditTypeCommand -> IndividualCreditType
        CreateMap<CreateCreditTypeCommand, IndividualCreditType>()
            .ForMember(dest => dest.Category, opt => opt.Ignore()) // Category'yi ignore et, constructor'da set edilecek
            .ForMember(dest => dest.IsActive, opt => opt.Ignore()) // IsActive'i ignore et, constructor'da set edilecek
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id'yi ignore et, constructor'da set edilecek
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore()) // CreatedDate'i ignore et, constructor'da set edilecek
            .ForMember(dest => dest.RequiredDocuments, opt => opt.Ignore()) // RequiredDocuments'i ignore et, constructor'da set edilecek
            .ForMember(dest => dest.MinAge, opt => opt.Ignore()) // MinAge'i ignore et, constructor'da set edilecek
            .ForMember(dest => dest.MaxAge, opt => opt.Ignore()) // MaxAge'i ignore et, constructor'da set edilecek
            .ForMember(dest => dest.MaxMonthlyIncome, opt => opt.MapFrom(src => src.MaxAmount * 0.3m)); // Maksimum aylık gelir = Maksimum kredi miktarının %30'u
        
        // IndividualCreditType -> CreateCreditTypeResponse
        CreateMap<IndividualCreditType, CreateCreditTypeResponse>();
        
        // IndividualCreditType -> CreditTypeDto
        CreateMap<IndividualCreditType, CreditTypeDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.SubCreditTypeCount, opt => opt.MapFrom(src => src.SubCreditTypes != null ? src.SubCreditTypes.Count : 0));
        
        // CorporateCreditType -> CreditTypeDto
        CreateMap<CorporateCreditType, CreditTypeDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.SubCreditTypeCount, opt => opt.MapFrom(src => src.SubCreditTypes != null ? src.SubCreditTypes.Count : 0));
        
        // IndividualCreditType -> GetCreditTypeByIdResponse
        CreateMap<IndividualCreditType, GetCreditTypeByIdResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.SubCreditTypeCount, opt => opt.MapFrom(src => src.SubCreditTypes != null ? src.SubCreditTypes.Count : 0));
        
        // CorporateCreditType -> GetCreditTypeByIdResponse
        CreateMap<CorporateCreditType, GetCreditTypeByIdResponse>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.SubCreditTypeCount, opt => opt.MapFrom(src => src.SubCreditTypes != null ? src.SubCreditTypes.Count : 0));
        
        // SubCreditType -> SubCreditTypeDto
        CreateMap<SubCreditType, SubCreditTypeDto>();
    }
}
