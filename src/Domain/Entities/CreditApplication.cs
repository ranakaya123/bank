using Bank.Core.Repositories;
using Bank.Domain.Enums;

namespace Bank.Domain.Entities;

public abstract class CreditApplication : Entity<Guid>
{
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    
    public Guid CreditTypeId { get; set; }
    public virtual CreditType CreditType { get; set; } = null!;
    
    public Guid? SubCreditTypeId { get; set; }
    public virtual SubCreditType? SubCreditType { get; set; }
    
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; } // Ay cinsinden
    public decimal MonthlyIncome { get; set; }
    public string Purpose { get; set; } = string.Empty;
    public ApplicationStatus Status { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? DecisionDate { get; set; }
    public string? RejectionReason { get; set; }
    
    // Kredi hesaplama sonuçları
    public decimal? ApprovedAmount { get; set; }
    public int? ApprovedTerm { get; set; }
    public decimal? MonthlyPayment { get; set; }
    public decimal? TotalPayment { get; set; }
    public decimal? InterestAmount { get; set; }
    
    // Navigation Properties
    public virtual ICollection<CreditApprovalHistory> CreditApprovalHistories { get; set; } = new List<CreditApprovalHistory>();
    
    public CreditApplication()
    {
        ApplicationDate = DateTime.UtcNow;
        Status = ApplicationStatus.Draft;
    }
}
