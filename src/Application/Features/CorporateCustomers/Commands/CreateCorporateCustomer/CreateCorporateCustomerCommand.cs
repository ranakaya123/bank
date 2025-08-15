using Bank.Application.Features.CorporateCustomers.Dtos;
using MediatR;

namespace Bank.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;

public class CreateCorporateCustomerCommand : IRequest<CreateCorporateCustomerResponseDto>
{
    public string CustomerNumber { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string TradeRegistryNumber { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string ContactPersonPhone { get; set; } = string.Empty;
    public string ContactPersonEmail { get; set; } = string.Empty;
    public string Sector { get; set; } = string.Empty;
    public DateTime EstablishmentDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}

