namespace Bank.Application.Features.CorporateCustomers.Dtos;

public class CreateCorporateCustomerResponseDto
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}
