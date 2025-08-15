using Bank.Application.Services.Repositories;
using Bank.Domain.Entities;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Bank.Core.CrossCuttingConcerns.Exceptions.Types;

namespace Bank.Application.Features.CreditTypes.Queries.GetCreditTypeById;

public class GetCreditTypeByIdQueryHandler : IRequestHandler<GetCreditTypeByIdQuery, GetCreditTypeByIdResponse>
{
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;

    public GetCreditTypeByIdQueryHandler(ICreditTypeRepository creditTypeRepository, IMapper mapper)
    {
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
    }

    public async Task<GetCreditTypeByIdResponse> Handle(GetCreditTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var creditType = await _creditTypeRepository.GetAsync(
            predicate: x => x.Id == request.Id,
            include: query => query
                .Include(x => x.SubCreditTypes),
            cancellationToken: cancellationToken
        );

        if (creditType == null)
            throw new NotFoundException($"Kredi türü bulunamadı. ID: {request.Id}");

        var response = _mapper.Map<GetCreditTypeByIdResponse>(creditType);
        return response;
    }
}
