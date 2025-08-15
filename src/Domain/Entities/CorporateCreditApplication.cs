namespace Bank.Domain.Entities;

public class CorporateCreditApplication : CreditApplication
{
    public string CompanyName { get; set; } = string.Empty;
    public string BusinessType { get; set; } = string.Empty;
    public int CompanyAge { get; set; } // Yıl cinsinden
    public decimal AnnualRevenue { get; set; }
    public int EmployeeCount { get; set; }
    public string TaxNumber { get; set; } = string.Empty;
    public string TradeRegistryNumber { get; set; } = string.Empty;
}
