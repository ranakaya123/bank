namespace Bank.Core.Security.Entity;

public class Operation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    
    // Navigation properties
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    
    public Operation()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
        CreatedDate = DateTime.UtcNow;
        IsActive = true;
    }
}
