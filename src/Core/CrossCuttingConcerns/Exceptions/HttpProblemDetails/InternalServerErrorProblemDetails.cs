using System.Net;

namespace Bank.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class InternalServerErrorProblemDetails : IProblemDetails
{
    public string Title { get; set; } = "Internal server error";
    public string Detail { get; set; } = string.Empty;
    public int? Status { get; set; } = (int)HttpStatusCode.InternalServerError;
    public string Type { get; set; } = "https://example.com/probs/internal";
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
