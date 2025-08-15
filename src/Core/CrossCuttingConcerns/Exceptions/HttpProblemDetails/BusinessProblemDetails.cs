using System.Net;

namespace Bank.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class BusinessProblemDetails : IProblemDetails
{
    public string Title { get; set; } = "Business rule violation";
    public string Detail { get; set; } = string.Empty;
    public int? Status { get; set; } = (int)HttpStatusCode.BadRequest;
    public string Type { get; set; } = "https://example.com/probs/business";
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
