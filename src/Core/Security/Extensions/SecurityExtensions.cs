using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Bank.Core.Security.JWT;

namespace Bank.Core.Security.Extensions;

public static class SecurityExtensions
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        services.AddAuthorization();
        
        return services;
    }

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>() ?? new string[0])
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });
        });

        return services;
    }

    public static IServiceCollection AddRateLimiting(this IServiceCollection services)
    {
        // .NET 9'da RateLimiting varsayılan olarak dahil
        // Gerekirse burada özel konfigürasyon eklenebilir
        return services;
    }
}
