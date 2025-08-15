using System.Net;

namespace Bank.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class AuthorizationProblemDetails : IProblemDetails
{
    public string Title { get; set; } = "Authorization error";
    public string Detail { get; set; } = string.Empty;
    public int? Status { get; set; } = (int)HttpStatusCode.Unauthorized;
    public string Type { get; set; } = "https://example.com/probs/authorization";
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
