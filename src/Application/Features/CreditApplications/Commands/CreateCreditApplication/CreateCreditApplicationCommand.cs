using MediatR;
using Bank.Core.Application.Common;

namespace Bank.Application.Features.CreditApplications.Commands.CreateCreditApplication;

public class CreateCreditApplicationCommand : IRequest<CreateCreditApplicationResponse>
{
    public Guid CustomerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public Guid? SubCreditTypeId { get; set; }
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
    public decimal MonthlyIncome { get; set; }
    public string Purpose { get; set; } = string.Empty;
    
    // IndividualCreditApplication için gerekli alanlar
    public string EmploymentType { get; set; } = string.Empty;
    public string EmployerName { get; set; } = string.Empty;
    public int EmploymentDuration { get; set; }
    public string CollateralType { get; set; } = string.Empty;
    public decimal? CollateralValue { get; set; }
}
