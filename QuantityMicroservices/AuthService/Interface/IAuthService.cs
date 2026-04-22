using AuthService.Models;
namespace AuthService.Interface;

public interface IAuthService
{
    Task<AuthResponseDTO> Register(RegisterDTO dto);
    Task<AuthResponseDTO> Login(LoginDTO dto);
}
