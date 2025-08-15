using Bank.Application.Features.IndividualCustomers.Dtos;
using MediatR;

namespace Bank.Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer;

public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerResponseDto>
{
    // Customer bilgileri
    public string CustomerNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    
    // User bilgileri (sistem girişi için)
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

