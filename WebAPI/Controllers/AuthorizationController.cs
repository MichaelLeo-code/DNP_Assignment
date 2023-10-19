using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Shared.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("login")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration config;
    private readonly IAuthorizationService authService;

    public AuthController(IConfiguration config, IAuthorizationService authService)
    {
        this.config = config;
        this.authService = authService;
    }
    
    private List<Claim> GenerateClaims(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("DisplayName", user.Name),
            new Claim("Email", user.Email),
            new Claim("Age", user.Age.ToString()),
            new Claim("Domain", user.Domain),
            new Claim("SecurityLevel", user.SecurityLevel.ToString())
        };
        return claims.ToList();
    }
}