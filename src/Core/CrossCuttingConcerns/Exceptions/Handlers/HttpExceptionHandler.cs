using Bank.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Bank.Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Bank.Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    public HttpResponse Response { get; set; } = null!;

    public HttpExceptionHandler()
    {
    }

    public override bool CanHandle(Exception exception)
    {
        return exception is BusinessException ||
               exception is ValidationException ||
               exception is AuthorizationException ||
               exception is NotFoundException;
    }

    protected override async Task HandleException(BusinessException businessException)
    {
        var problemDetails = new BusinessProblemDetails { Detail = businessException.Message };
        await WriteProblemDetailsAsync(problemDetails);
    }

    protected override async Task HandleException(ValidationException validationException)
    {
        var problemDetails = new ValidationProblemDetails { Detail = validationException.Message };
        await WriteProblemDetailsAsync(problemDetails);
    }

    protected override async Task HandleException(AuthorizationException authorizationException)
    {
        var problemDetails = new AuthorizationProblemDetails { Detail = authorizationException.Message };
        await WriteProblemDetailsAsync(problemDetails);
    }

    protected override async Task HandleException(Exception exception)
    {
        IProblemDetails problemDetails;
        
        if (exception is NotFoundException notFoundException)
            problemDetails = new NotFoundProblemDetails { Detail = notFoundException.Message };
        else
            problemDetails = new InternalServerErrorProblemDetails { Detail = "An unexpected error occurred." };

        await WriteProblemDetailsAsync(problemDetails);
    }

    private async Task WriteProblemDetailsAsync(IProblemDetails problemDetails)
    {
        Response.StatusCode = problemDetails.Status ?? 500;
        Response.ContentType = "application/problem+json";

        var json = System.Text.Json.JsonSerializer.Serialize(problemDetails);
        await Response.WriteAsync(json);
    }
}
