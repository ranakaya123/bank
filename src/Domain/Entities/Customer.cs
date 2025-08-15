using Bank.Core.Repositories;

namespace Bank.Domain.Entities;

public abstract class Customer : Entity<Guid>
{
    public string CustomerNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime RegistrationDate { get; set; }

    protected Customer()
    {
        RegistrationDate = DateTime.UtcNow;
    }
}
