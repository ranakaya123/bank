using Bank.Core.Repositories;
using Bank.Domain.Entities;

namespace Bank.Application.Features.CreditTypes.Queries.GetCreditTypeList;

public class GetCreditTypeListResponse : Paginate<CreditTypeDto>
{
    public GetCreditTypeListResponse(List<CreditTypeDto> items, Paginate<CreditType> paginate) 
        : base(items, paginate.Index, paginate.Size, paginate.From)
    {
    }
}

public class CreditTypeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; }
    public int MaxTerm { get; set; }
    public decimal InterestRate { get; set; }
    public string Category { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public int SubCreditTypeCount { get; set; }
}
