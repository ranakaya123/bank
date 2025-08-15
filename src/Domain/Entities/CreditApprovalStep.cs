using Bank.Core.Repositories;
using Bank.Domain.Enums;

namespace Bank.Domain.Entities;

public class CreditApprovalStep : Entity<Guid>
{
    public Guid CreditTypeId { get; set; }
    public virtual CreditType CreditType { get; set; } = null!;
    
    public string StepName { get; set; } = string.Empty;
    public string StepDescription { get; set; } = string.Empty;
    public ApprovalStepType Type { get; set; }
    public int Order { get; set; } // Adım sırası
    public bool IsRequired { get; set; }
    public bool IsActive { get; set; }
    
    // Navigation Properties
    public virtual ICollection<CreditApprovalHistory> CreditApprovalHistories { get; set; } = new List<CreditApprovalHistory>();
}
