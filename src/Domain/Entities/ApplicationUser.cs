using Bank.Core.Repositories;
using Bank.Core.Security.Entity;

namespace Bank.Domain.Entities;

public class ApplicationUser : Entity<Guid>
{
    public int UserId { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerType { get; set; } = string.Empty; // "Individual" or "Corporate"

    // Navigation properties
    public virtual User User { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;

    public ApplicationUser()
    {
    }

    // Factory methods
    public static ApplicationUser CreateIndividualUser(
        string customerNumber, 
        string firstName, 
        string lastName, 
        string nationalId, 
        DateTime dateOfBirth, 
        string gender,
        string email,
        string phone,
        string address)
    {
        var individualCustomer = new IndividualCustomer
        {
            CustomerNumber = customerNumber,
            FirstName = firstName,
            LastName = lastName,
            NationalId = nationalId,
            DateOfBirth = dateOfBirth,
            Gender = gender,
            Email = email,
            Phone = phone,
            Address = address,
            Name = $"{firstName} {lastName}"
        };

        var appUser = new ApplicationUser
        {
            CustomerId = individualCustomer.Id,
            CustomerType = "Individual"
        };

        return appUser;
    }

    public static ApplicationUser CreateCorporateUser(
        string customerNumber,
        string companyName,
        string taxNumber,
        string tradeRegistryNumber,
        string contactPerson,
        string contactPersonPhone,
        string contactPersonEmail,
        string sector,
        DateTime establishmentDate,
        string email,
        string phone,
        string address)
    {
        var corporateCustomer = new CorporateCustomer
        {
            CustomerNumber = customerNumber,
            Name = companyName,
            Email = email,
            Phone = phone,
            Address = address,
            CompanyName = companyName,
            TaxNumber = taxNumber,
            TradeRegistryNumber = tradeRegistryNumber,
            ContactPerson = contactPerson,
            ContactPersonPhone = contactPersonPhone,
            ContactPersonEmail = contactPersonEmail,
            Sector = sector,
            EstablishmentDate = establishmentDate
        };

        var appUser = new ApplicationUser
        {
            CustomerId = corporateCustomer.Id,
            CustomerType = "Corporate"
        };

        return appUser;
    }
}
