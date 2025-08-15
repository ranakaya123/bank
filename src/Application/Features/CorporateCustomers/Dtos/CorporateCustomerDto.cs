namespace Bank.Application.Features.CorporateCustomers.Dtos;

public class CorporateCustomerDto
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string Sector { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime RegistrationDate { get; set; }
}
