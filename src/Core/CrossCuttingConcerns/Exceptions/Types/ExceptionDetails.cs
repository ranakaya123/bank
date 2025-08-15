namespace Bank.Core.CrossCuttingConcerns.Exceptions.Types;

public class ExceptionDetails
{
    public string Title { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Status { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string? TraceId { get; set; }
}
