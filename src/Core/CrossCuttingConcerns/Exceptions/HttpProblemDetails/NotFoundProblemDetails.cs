using System.Net;

namespace Bank.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class NotFoundProblemDetails : IProblemDetails
{
    public string Title { get; set; } = "Not found";
    public string Detail { get; set; } = string.Empty;
    public int? Status { get; set; } = (int)HttpStatusCode.NotFound;
    public string Type { get; set; } = "https://example.com/probs/notfound";
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
