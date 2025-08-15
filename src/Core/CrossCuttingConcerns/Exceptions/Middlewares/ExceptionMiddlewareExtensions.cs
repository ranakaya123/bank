using Microsoft.AspNetCore.Builder;

namespace Bank.Core.CrossCuttingConcerns.Exceptions.Middlewares;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }
}
