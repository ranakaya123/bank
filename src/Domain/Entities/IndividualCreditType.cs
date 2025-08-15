using Bank.Domain.Enums;

namespace Bank.Domain.Entities;

public class IndividualCreditType : CreditType
{
    public string RequiredDocuments { get; set; } = string.Empty;
    public decimal MaxMonthlyIncome { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    
    public IndividualCreditType() : base()
    {
        Category = CreditCategory.Individual;
        RequiredDocuments = "TC Kimlik, Maaş Bordrosu, Banka Hesap Ekstresi";
        MinAge = 18;
        MaxAge = 65;
        // MaxMonthlyIncome alanı handler'da set edilecek
    }
}
