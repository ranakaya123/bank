using Bank.Core.Repositories;

namespace Bank.Domain.Entities;

public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string TradeRegistryNumber { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string ContactPersonPhone { get; set; } = string.Empty;
    public string ContactPersonEmail { get; set; } = string.Empty;
    public string Sector { get; set; } = string.Empty;
    public DateTime EstablishmentDate { get; set; }

    public CorporateCustomer() : base()
    {
    }
}
