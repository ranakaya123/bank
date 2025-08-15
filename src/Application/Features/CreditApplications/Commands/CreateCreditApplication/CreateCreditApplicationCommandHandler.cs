using Bank.Application.Services.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;
using MediatR;
using Bank.Core.Repositories;
using AutoMapper;

namespace Bank.Application.Features.CreditApplications.Commands.CreateCreditApplication;

public class CreateCreditApplicationCommandHandler : IRequestHandler<CreateCreditApplicationCommand, CreateCreditApplicationResponse>
{
    private readonly ICreditApplicationRepository _creditApplicationRepository;
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCreditApplicationCommandHandler(
        ICreditApplicationRepository creditApplicationRepository,
        ICreditTypeRepository creditTypeRepository,
        ICustomerRepository customerRepository,
        IMapper mapper)
    {
        _creditApplicationRepository = creditApplicationRepository;
        _creditTypeRepository = creditTypeRepository;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CreateCreditApplicationResponse> Handle(CreateCreditApplicationCommand request, CancellationToken cancellationToken)
    {
        // Müşteri kontrolü
        var customer = await _customerRepository.GetAsync(x => x.Id == request.CustomerId);
        if (customer == null)
            throw new InvalidOperationException("Müşteri bulunamadı.");

        // Kredi türü kontrolü
        var creditType = await _creditTypeRepository.GetAsync(x => x.Id == request.CreditTypeId);
        if (creditType == null)
            throw new InvalidOperationException("Kredi türü bulunamadı.");

        // Aktif kredi türü kontrolü
        if (!creditType.IsActive)
            throw new InvalidOperationException("Bu kredi türü aktif değil.");

        // Miktar kontrolü
        if (request.RequestedAmount < creditType.MinAmount || request.RequestedAmount > creditType.MaxAmount)
            throw new InvalidOperationException($"Talep edilen miktar {creditType.MinAmount:C} - {creditType.MaxAmount:C} arasında olmalıdır.");

        // Vade kontrolü
        if (request.RequestedTerm < creditType.MinTerm || request.RequestedTerm > creditType.MaxTerm)
            throw new InvalidOperationException($"Talep edilen vade {creditType.MinTerm} - {creditType.MaxTerm} ay arasında olmalıdır.");

        // Aktif başvuru kontrolü
        if (await _creditApplicationRepository.HasActiveApplicationAsync(request.CustomerId, request.CreditTypeId))
            throw new InvalidOperationException("Bu kredi türü için zaten aktif bir başvurunuz bulunmaktadır.");

        // Kredi başvurusu oluştur (AutoMapper ile)
        var creditApplication = _mapper.Map<IndividualCreditApplication>(request);
        creditApplication.Status = ApplicationStatus.Draft;

        var createdApplication = await _creditApplicationRepository.AddAsync(creditApplication);

        return _mapper.Map<CreateCreditApplicationResponse>(createdApplication);
    }
}
