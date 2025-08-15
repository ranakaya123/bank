namespace Bank.Domain.Entities;

public class CorporateCreditType : CreditType
{
    public string BusinessRequirements { get; set; } = string.Empty;
    public int MinCompanyAge { get; set; } // Yıl cinsinden
    public decimal MinAnnualRevenue { get; set; }
    public string RequiredLicenses { get; set; } = string.Empty;
    
    public CorporateCreditType()
    {
        Category = Enums.CreditCategory.Corporate;
    }
}
