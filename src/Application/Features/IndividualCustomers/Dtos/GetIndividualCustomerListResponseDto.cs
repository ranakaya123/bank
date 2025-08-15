namespace Bank.Application.Features.IndividualCustomers.Dtos;

public class GetIndividualCustomerListResponseDto
{
    public List<IndividualCustomerDto> Items { get; set; } = new();
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}
