using Bank.Domain.Enums;

namespace Bank.Application.Features.CreditApplications.Commands.CreateCreditApplication;

public class CreateCreditApplicationResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid CreditTypeId { get; set; }
    public Guid? SubCreditTypeId { get; set; }
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
    public decimal MonthlyIncome { get; set; }
    public string Purpose { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime ApplicationDate { get; set; }
    public decimal? ApprovedAmount { get; set; }
    public decimal? MonthlyPayment { get; set; }
    public decimal? TotalPayment { get; set; }
    public decimal? InterestAmount { get; set; }
    
    // IndividualCreditApplication için ek alanlar
    public string EmploymentType { get; set; } = string.Empty;
    public string EmployerName { get; set; } = string.Empty;
    public int EmploymentDuration { get; set; }
    public string CollateralType { get; set; } = string.Empty;
    public decimal? CollateralValue { get; set; }
}
