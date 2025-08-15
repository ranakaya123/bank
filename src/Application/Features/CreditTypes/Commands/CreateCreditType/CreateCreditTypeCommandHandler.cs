using Bank.Application.Services.Repositories;
using Bank.Domain.Entities;
using Bank.Domain.Enums;
using MediatR;
using Bank.Core.Repositories;
using AutoMapper;

namespace Bank.Application.Features.CreditTypes.Commands.CreateCreditType;

public class CreateCreditTypeCommandHandler : IRequestHandler<CreateCreditTypeCommand, CreateCreditTypeResponse>
{
    private readonly ICreditTypeRepository _creditTypeRepository;
    private readonly IMapper _mapper;

    public CreateCreditTypeCommandHandler(
        ICreditTypeRepository creditTypeRepository, 
        IMapper mapper)
    {
        _creditTypeRepository = creditTypeRepository;
        _mapper = mapper;
    }

    public async Task<CreateCreditTypeResponse> Handle(CreateCreditTypeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Basit validation
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("Kredi türü adı boş olamaz.");
            }

            // Manuel entity oluştur (AutoMapper olmadan)
            var creditType = new IndividualCreditType
            {
                Name = request.Name,
                Description = request.Description,
                MinAmount = request.MinAmount,
                MaxAmount = request.MaxAmount,
                MinTerm = request.MinTerm,
                MaxTerm = request.MaxTerm,
                InterestRate = request.InterestRate,
                Category = CreditCategory.Individual,
                IsActive = true,
                // IndividualCreditType için gerekli alanlar
                MaxMonthlyIncome = request.MaxAmount * 0.3m, // Maksimum aylık gelir = Maksimum kredi miktarının %30'u
                RequiredDocuments = "TC Kimlik, Maaş Bordrosu, Banka Hesap Ekstresi",
                MinAge = 18,
                MaxAge = 65
            };

            // Repository'ye kaydet
            var createdCreditType = await _creditTypeRepository.AddAsync(creditType);

            // Response oluştur
            var response = new CreateCreditTypeResponse
            {
                Id = createdCreditType.Id,
                Name = createdCreditType.Name,
                Description = createdCreditType.Description,
                MinAmount = createdCreditType.MinAmount,
                MaxAmount = createdCreditType.MaxAmount,
                MinTerm = createdCreditType.MinTerm,
                MaxTerm = createdCreditType.MaxTerm,
                InterestRate = createdCreditType.InterestRate,
                Category = createdCreditType.Category,
                IsActive = createdCreditType.IsActive,
                CreatedDate = createdCreditType.CreatedDate
            };

            return response;
        }
        catch (Exception ex)
        {
            // Hata detayını log'la
            Console.WriteLine($"Hata: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            throw;
        }
    }
}
