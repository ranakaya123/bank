namespace Bank.Core.CrossCuttingConcerns.Exceptions.Types;

public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message) : base(message) { }
}
