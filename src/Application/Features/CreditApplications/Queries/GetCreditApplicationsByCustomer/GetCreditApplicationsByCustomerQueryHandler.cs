using Bank.Application.Services.Repositories;
using Bank.Domain.Entities;
using MediatR;
using Bank.Core.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Features.CreditApplications.Queries.GetCreditApplicationsByCustomer;

public class GetCreditApplicationsByCustomerQueryHandler : IRequestHandler<GetCreditApplicationsByCustomerQuery, GetCreditApplicationsByCustomerResponse>
{
    private readonly ICreditApplicationRepository _creditApplicationRepository;
    private readonly IMapper _mapper;

    public GetCreditApplicationsByCustomerQueryHandler(ICreditApplicationRepository creditApplicationRepository, IMapper mapper)
    {
        _creditApplicationRepository = creditApplicationRepository;
        _mapper = mapper;
    }

    public async Task<GetCreditApplicationsByCustomerResponse> Handle(GetCreditApplicationsByCustomerQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.True<CreditApplication>();
        predicate = predicate.And(x => x.CustomerId == request.CustomerId);

        var result = await _creditApplicationRepository.GetListAsync(
            predicate: predicate,
            include: query => query
                .Include(x => x.Customer)
                .Include(x => x.CreditType),
            index: 0,
            size: 1000, // Müşteri başına maksimum 1000 başvuru (daha fazla başvuru olabilir)
            cancellationToken: cancellationToken
        );

        var creditApplicationDtos = _mapper.Map<List<CreditApplicationDto>>(result.Items);

        return new GetCreditApplicationsByCustomerResponse(creditApplicationDtos, result);
    }
}
