using Bank.Application.Features.IndividualCustomers.Dtos;
using Bank.Application.Services.Repositories;
using Bank.Core.Repositories;
using MediatR;

namespace Bank.Application.Features.IndividualCustomers.Queries.GetIndividualCustomerList;

public class GetIndividualCustomerListQueryHandler : IRequestHandler<GetIndividualCustomerListQuery, GetIndividualCustomerListResponseDto>
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public GetIndividualCustomerListQueryHandler(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task<GetIndividualCustomerListResponseDto> Handle(GetIndividualCustomerListQuery request, CancellationToken cancellationToken)
    {
        var paginate = await _individualCustomerRepository.GetListAsync(
            index: request.PageIndex,
            size: request.PageSize,
            cancellationToken: cancellationToken);

        var response = new GetIndividualCustomerListResponseDto
        {
            Index = paginate.Index,
            Size = paginate.Size,
            Count = paginate.Count,
            Pages = paginate.Pages,
            HasPrevious = paginate.HasPrevious,
            HasNext = paginate.HasNext,
            Items = paginate.Items.Select(x => new IndividualCustomerDto
            {
                Id = x.Id,
                CustomerNumber = x.CustomerNumber,
                FullName = x.FullName,
                Email = x.Email,
                Phone = x.Phone,
                IsActive = x.IsActive,
                RegistrationDate = x.RegistrationDate
            }).ToList()
        };

        return response;
    }
}

