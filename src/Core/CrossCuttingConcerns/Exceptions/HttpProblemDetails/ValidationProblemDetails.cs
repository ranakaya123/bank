using System.Net;

namespace Bank.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class ValidationProblemDetails : IProblemDetails
{
    public string Title { get; set; } = "Validation error";
    public string Detail { get; set; } = string.Empty;
    public int? Status { get; set; } = (int)HttpStatusCode.BadRequest;
    public string Type { get; set; } = "https://example.com/probs/validation";
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
