using MediatR;
using Bank.Core.Application.Common;
using Bank.Domain.Enums;

namespace Bank.Application.Features.CreditTypes.Commands.CreateCreditType;

public class CreateCreditTypeCommand : IRequest<CreateCreditTypeResponse>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; }
    public int MaxTerm { get; set; }
    public decimal InterestRate { get; set; }
    public CreditCategory Category { get; set; } = CreditCategory.Individual;
}
