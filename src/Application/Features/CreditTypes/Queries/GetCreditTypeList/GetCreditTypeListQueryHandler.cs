using Bank.Application.Services.Repositories;
using Bank.Domain.Enums;
using Bank.Domain.Entities;
using MediatR;
using Bank.Core.Repositories;
using AutoMapper;

namespace Bank.Application.Features.CreditTypes.Queries.GetCreditTypeList;

public class GetCreditTypeListQueryHandler : IRequestHandler<GetCreditTypeListQuery, GetCreditTypeListResponse>
{
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;

    public GetCreditTypeListQueryHandler(ICreditTypeRepository creditTypeRepository, IMapper mapper)
    {
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
    }

    public async Task<GetCreditTypeListResponse> Handle(GetCreditTypeListQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.True<CreditType>();

        if (!string.IsNullOrEmpty(request.Category))
            predicate = predicate.And(x => x.Category.ToString() == request.Category);

        if (request.IsActive.HasValue)
            predicate = predicate.And(x => x.IsActive == request.IsActive.Value);

        var result = await _creditTypeRepository.GetListAsync(
            predicate: predicate,
            index: request.Page,
            size: request.Size,
            cancellationToken: cancellationToken
        );

        var creditTypeDtos = _mapper.Map<List<CreditTypeDto>>(result.Items);

        return new GetCreditTypeListResponse(creditTypeDtos, result);
    }
}
