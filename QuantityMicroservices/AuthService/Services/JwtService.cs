using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Models;
using AuthService.Interface;

using Microsoft.IdentityModel.Tokens;

namespace AuthService.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _config;

    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user)
    {
        // Secret key came from appsettings.json 
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Info store hogi in the token 
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),   // UserId
                new Claim(JwtRegisteredClaimNames.Email, user.Email),          // Email
                new Claim("fullName", user.FullName),                          // Name
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Unique ID
            };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),   // Token expires in 1 hour
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

