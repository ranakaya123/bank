using Bank.Core.Repositories;

namespace Bank.Domain.Entities;

public class SubCreditType : Entity<Guid>
{
    public Guid CreditTypeId { get; set; }
    public virtual CreditType CreditType { get; set; } = null!;
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal SpecificInterestRate { get; set; } // Ana türden farklı olabilir
    public string SpecialConditions { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    
    // Navigation Properties
    public virtual ICollection<CreditApplication> CreditApplications { get; set; } = new List<CreditApplication>();
}
