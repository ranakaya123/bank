using Bank.Core.Repositories;
using Bank.Domain.Enums;

namespace Bank.Domain.Entities;

public class CreditCalculationRule : Entity<Guid>
{
    public Guid CreditTypeId { get; set; }
    public virtual CreditType CreditType { get; set; } = null!;
    
    public string RuleName { get; set; } = string.Empty;
    public string RuleDescription { get; set; } = string.Empty;
    public RuleType Type { get; set; }
    public string Formula { get; set; } = string.Empty; // JSON veya expression
    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }
    public int Priority { get; set; } // Kural önceliği
    public bool IsActive { get; set; }
}
