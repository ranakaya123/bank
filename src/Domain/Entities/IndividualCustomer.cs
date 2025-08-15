using Bank.Core.Repositories;

namespace Bank.Domain.Entities;

public class IndividualCustomer : Customer
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    public IndividualCustomer() : base()
    {
    }
}
