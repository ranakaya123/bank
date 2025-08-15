using Bank.Core.CrossCuttingConcerns.Exceptions.Types;

namespace Bank.Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception)
    {
        if (exception is BusinessException businessException)
            return HandleException(businessException);
        else if (exception is ValidationException validationException)
            return HandleException(validationException);
        else if (exception is AuthorizationException authorizationException)
            return HandleException(authorizationException);
        else
            return HandleException(exception);
    }

    public abstract bool CanHandle(Exception exception);

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(ValidationException validationException);
    protected abstract Task HandleException(AuthorizationException authorizationException);
    protected abstract Task HandleException(Exception exception);
}
