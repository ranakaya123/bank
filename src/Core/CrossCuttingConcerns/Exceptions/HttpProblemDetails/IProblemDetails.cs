namespace Bank.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public interface IProblemDetails
{
    string Title { get; set; }
    string Detail { get; set; }
    int? Status { get; set; }
    string Type { get; set; }
    DateTime Timestamp { get; set; }
}
