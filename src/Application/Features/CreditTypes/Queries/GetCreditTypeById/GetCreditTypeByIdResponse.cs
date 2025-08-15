namespace Bank.Application.Features.CreditTypes.Queries.GetCreditTypeById;

public class GetCreditTypeByIdResponse
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
    public List<SubCreditTypeDto> SubCreditTypes { get; set; } = new();
}

public class SubCreditTypeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int MinTerm { get; set; }
    public int MaxTerm { get; set; }
    public decimal InterestRate { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}
