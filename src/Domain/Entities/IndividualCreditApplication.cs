namespace Bank.Domain.Entities;

public class IndividualCreditApplication : CreditApplication
{
    public string EmploymentType { get; set; } = string.Empty; // Maaşlı, Serbest, Emekli
    public string EmployerName { get; set; } = string.Empty;
    public int EmploymentDuration { get; set; } // Ay cinsinden
    public string CollateralType { get; set; } = string.Empty; // Teminat türü
    public decimal? CollateralValue { get; set; }
}
