namespace Bank.Application.Features.IndividualCustomers.Dtos;

public class UpdateIndividualCustomerResponseDto
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime UpdatedDate { get; set; }
    public string Message { get; set; } = string.Empty;
}
