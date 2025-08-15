using Bank.Core.Repositories;
using Bank.Domain.Entities;

namespace Bank.Application.Features.CreditApplications.Queries.GetCreditApplicationsByCustomer;

public class GetCreditApplicationsByCustomerResponse : Paginate<CreditApplicationDto>
{
    public GetCreditApplicationsByCustomerResponse(List<CreditApplicationDto> items, Paginate<CreditApplication> paginate) 
        : base(items, paginate.Index, paginate.Size, paginate.From)
    {
    }
}

public class CreditApplicationDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public Guid CreditTypeId { get; set; }
    public string CreditTypeName { get; set; } = string.Empty;
    public decimal RequestedAmount { get; set; }
    public int RequestedTerm { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal TotalPayment { get; set; }
    public string ApplicationStatus { get; set; } = string.Empty;
    public DateTime ApplicationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime CreatedDate { get; set; }
}
