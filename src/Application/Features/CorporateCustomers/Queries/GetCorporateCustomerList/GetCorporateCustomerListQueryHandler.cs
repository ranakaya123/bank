using Bank.Application.Features.CorporateCustomers.Dtos;
using Bank.Application.Services.Repositories;
using MediatR;

namespace Bank.Application.Features.CorporateCustomers.Queries.GetCorporateCustomerList;

public class GetCorporateCustomerListQueryHandler : IRequestHandler<GetCorporateCustomerListQuery, GetCorporateCustomerListResponseDto>
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public GetCorporateCustomerListQueryHandler(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task<GetCorporateCustomerListResponseDto> Handle(GetCorporateCustomerListQuery request, CancellationToken cancellationToken)
    {
        var paginate = await _corporateCustomerRepository.GetListAsync(
            index: request.PageIndex,
            size: request.PageSize,
            cancellationToken: cancellationToken);

        var response = new GetCorporateCustomerListResponseDto
        {
            Index = paginate.Index,
            Size = paginate.Size,
            Count = paginate.Count,
            Pages = paginate.Pages,
            HasPrevious = paginate.HasPrevious,
            HasNext = paginate.HasNext,
            Items = paginate.Items.Select(x => new CorporateCustomerDto
            {
                Id = x.Id,
                CustomerNumber = x.CustomerNumber,
                CompanyName = x.CompanyName,
                TaxNumber = x.TaxNumber,
                Sector = x.Sector,
                ContactPerson = x.ContactPerson,
                Email = x.Email,
                IsActive = x.IsActive,
                RegistrationDate = x.RegistrationDate
            }).ToList()
        };

        return response;
    }
}

