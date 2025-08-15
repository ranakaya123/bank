using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Bank.Core.Application.Common;

namespace Bank.Core.Application.Common.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is not ISecuredRequest securedRequest)
        {
            return await next();
        }

        var user = _httpContextAccessor.HttpContext?.User;
        if (user?.Identity?.IsAuthenticated != true)
        {
            throw new UnauthorizedAccessException("Kullanıcı kimlik doğrulaması yapılmamış.");
        }

        var userRoles = user.Claims
            .Where(c => c.Type == ClaimTypes.Role || c.Type == "Role")
            .Select(c => c.Value)
            .ToArray();

        var requiredRoles = securedRequest.Roles;
        if (requiredRoles.Any() && !requiredRoles.Any(role => userRoles.Contains(role)))
        {
            throw new UnauthorizedAccessException("Bu işlem için yetkiniz bulunmamaktadır.");
        }

        return await next();
    }
}
