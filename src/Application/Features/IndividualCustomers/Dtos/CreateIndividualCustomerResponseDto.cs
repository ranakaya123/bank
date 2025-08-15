namespace Bank.Application.Features.IndividualCustomers.Dtos;

public class CreateIndividualCustomerResponseDto
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}
