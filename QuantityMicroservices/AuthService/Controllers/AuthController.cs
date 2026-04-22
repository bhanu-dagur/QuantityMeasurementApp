using AuthService.Models;
using AuthService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    // Auth Controller
    // Base URL: /api/auth
    
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST /api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            try
            {
                var response = await _authService.Register(dto);
                return Ok(new
                {
                    success = true,
                    message = "Registration successful!",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        // POST /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var response = await _authService.Login(dto);
                return Ok(new
                {
                    success = true,
                    message = "Login successful!",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
        }
    }
}
