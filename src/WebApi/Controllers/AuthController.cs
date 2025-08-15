using Microsoft.AspNetCore.Mvc;
using Bank.Core.Security.JWT;
using Bank.Core.Security.Claims;
using System.Security.Claims;
using Bank.Core.Application.Common;

namespace Bank.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IJwtHelper _jwtHelper;

    public AuthController(IJwtHelper jwtHelper)
    {
        _jwtHelper = jwtHelper;
    }

    /// <summary>
    /// Müşteri girişi yapar ve JWT token döner
    /// </summary>
    /// <param name="request">Giriş bilgileri</param>
    /// <returns>JWT token</returns>
    [HttpPost("customer-login")]
    public ActionResult<LoginResponse> CustomerLogin([FromBody] CustomerLoginRequest request)
    {
        // Gerçek uygulamada burada veritabanından kullanıcı doğrulanır
        if (request.Email == "customer@bank.com" && request.Password == "123456")
        {
            var claims = new List<Claim>
            {
                new Claim(UserClaims.UserId, Guid.NewGuid().ToString()),
                new Claim(UserClaims.UserName, request.Email),
                new Claim(UserClaims.Email, request.Email),
                new Claim(UserClaims.Role, UserRoles.Customer),
                new Claim(UserClaims.CustomerId, Guid.NewGuid().ToString())
            };

            var token = _jwtHelper.CreateToken(claims);
            var refreshToken = _jwtHelper.CreateRefreshToken();

            return Ok(new LoginResponse
            {
                Token = token.Token,
                Expiration = token.Expiration,
                RefreshToken = refreshToken,
                UserRole = UserRoles.Customer
            });
        }

        return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre" });
    }

    /// <summary>
    /// Banka personeli girişi yapar ve JWT token döner
    /// </summary>
    /// <param name="request">Giriş bilgileri</param>
    /// <returns>JWT token</returns>
    [HttpPost("employee-login")]
    public ActionResult<LoginResponse> EmployeeLogin([FromBody] EmployeeLoginRequest request)
    {
        // Gerçek uygulamada burada veritabanından kullanıcı doğrulanır
        if (request.Email == "employee@bank.com" && request.Password == "123456")
        {
            var claims = new List<Claim>
            {
                new Claim(UserClaims.UserId, Guid.NewGuid().ToString()),
                new Claim(UserClaims.UserName, request.Email),
                new Claim(UserClaims.Email, request.Email),
                new Claim(UserClaims.Role, UserRoles.BankEmployee),
                new Claim(UserClaims.BankEmployeeId, Guid.NewGuid().ToString())
            };

            var token = _jwtHelper.CreateToken(claims);
            var refreshToken = _jwtHelper.CreateRefreshToken();

            return Ok(new LoginResponse
            {
                Token = token.Token,
                Expiration = token.Expiration,
                RefreshToken = refreshToken,
                UserRole = UserRoles.BankEmployee
            });
        }

        return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre" });
    }

    /// <summary>
    /// Admin girişi yapar ve JWT token döner
    /// </summary>
    /// <param name="request">Giriş bilgileri</param>
    /// <returns>JWT token</returns>
    [HttpPost("admin-login")]
    public ActionResult<LoginResponse> AdminLogin([FromBody] AdminLoginRequest request)
    {
        // Gerçek uygulamada burada veritabanından kullanıcı doğrulanır
        if (request.Email == "admin@bank.com" && request.Password == "123456")
        {
            var claims = new List<Claim>
            {
                new Claim(UserClaims.UserId, Guid.NewGuid().ToString()),
                new Claim(UserClaims.UserName, request.Email),
                new Claim(UserClaims.Email, request.Email),
                new Claim(UserClaims.Role, UserRoles.Admin)
            };

            var token = _jwtHelper.CreateToken(claims);
            var refreshToken = _jwtHelper.CreateRefreshToken();

            return Ok(new LoginResponse
            {
                Token = token.Token,
                Expiration = token.Expiration,
                RefreshToken = refreshToken,
                UserRole = UserRoles.Admin
            });
        }

        return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre" });
    }

    /// <summary>
    /// Token'ı yeniler
    /// </summary>
    /// <param name="request">Refresh token bilgisi</param>
    /// <returns>Yeni JWT token</returns>
    [HttpPost("refresh-token")]
    public ActionResult<LoginResponse> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        // Gerçek uygulamada burada refresh token veritabanından doğrulanır
        var principal = _jwtHelper.GetPrincipalFromExpiredToken(request.Token);
        if (principal == null)
        {
            return BadRequest(new { message = "Geçersiz token" });
        }

        var claims = principal.Claims.ToList();
        var token = _jwtHelper.CreateToken(claims);
        var refreshToken = _jwtHelper.CreateRefreshToken();

        return Ok(new LoginResponse
        {
            Token = token.Token,
            Expiration = token.Expiration,
            RefreshToken = refreshToken,
            UserRole = claims.FirstOrDefault(c => c.Type == UserClaims.Role)?.Value ?? "Unknown"
        });
    }
}

// DTOs
public class CustomerLoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class EmployeeLoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class AdminLoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class RefreshTokenRequest
{
    public string Token { get; set; } = string.Empty;
}

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public string UserRole { get; set; } = string.Empty;
}

