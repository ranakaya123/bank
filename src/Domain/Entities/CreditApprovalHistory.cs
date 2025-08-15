using Bank.Core.Repositories;
using Bank.Domain.Enums;

namespace Bank.Domain.Entities;

public class CreditApprovalHistory : Entity<Guid>
{
    public Guid CreditApplicationId { get; set; }
    public virtual CreditApplication CreditApplication { get; set; } = null!;
    
    public Guid CreditApprovalStepId { get; set; }
    public virtual CreditApprovalStep CreditApprovalStep { get; set; } = null!;
    
    public ApprovalStatus Status { get; set; }
    public string? Notes { get; set; }
    public Guid? ApprovedByUserId { get; set; }
    public DateTime ProcessDate { get; set; }
    
    public CreditApprovalHistory()
    {
        ProcessDate = DateTime.UtcNow;
    }
}
