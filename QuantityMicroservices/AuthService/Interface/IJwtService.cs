using AuthService.Models;

namespace AuthService.Interface;

public interface IJwtService
{
    public string GenerateToken(User user);
}