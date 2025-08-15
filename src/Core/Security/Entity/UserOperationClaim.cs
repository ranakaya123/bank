namespace Bank.Core.Security.Entity;

public class UserOperationClaim
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationId { get; set; }
    public DateTime CreatedDate { get; set; }
    
    // Navigation properties
    public virtual User User { get; set; }
    public virtual Operation Operation { get; set; }
    
    public UserOperationClaim()
    {
        CreatedDate = DateTime.UtcNow;
    }
}
