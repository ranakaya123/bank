using Bank.Core.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;

namespace Bank.Core.CrossCuttingConcerns.Exceptions.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _httpExceptionHandler = new HttpExceptionHandler();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        _httpExceptionHandler.Response = context.Response;
        return _httpExceptionHandler.HandleExceptionAsync(exception);
    }
}
