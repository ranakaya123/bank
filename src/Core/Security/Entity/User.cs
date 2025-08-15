using Bank.Core.Repositories;

namespace Bank.Core.Security.Entity;

public class User : Entity<int>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime? LastLoginDate { get; set; }
    
    // Navigation properties
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    
    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
        IsActive = true;
    }
}
