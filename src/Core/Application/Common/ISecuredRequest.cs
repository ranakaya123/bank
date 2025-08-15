namespace Bank.Core.Application.Common;

public interface ISecuredRequest
{
    string[] Roles { get; }
}
