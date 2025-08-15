using Bank.Core.Repositories;
using Bank.Domain.Enums;

namespace Bank.Domain.Entities;

public abstract class CreditType : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; } // Ay cinsinden
    public int MaxTerm { get; set; } // Ay cinsinden
    public decimal InterestRate { get; set; } // Yıllık faiz oranı
    public bool IsActive { get; set; }
    public CreditCategory Category { get; set; }
    
    // Navigation Properties
    public virtual ICollection<SubCreditType> SubCreditTypes { get; set; } = new List<SubCreditType>();
    public virtual ICollection<CreditApplication> CreditApplications { get; set; } = new List<CreditApplication>();
    public virtual ICollection<CreditCalculationRule> CreditCalculationRules { get; set; } = new List<CreditCalculationRule>();
    public virtual ICollection<CreditApprovalStep> CreditApprovalSteps { get; set; } = new List<CreditApprovalStep>();
    
    protected CreditType()
    {
        Id = Guid.NewGuid();
        IsActive = true;
    }
}
