using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuantityMeasurementAPI.Controller;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTO;
using QuantityMeasurementAppRepositoryLayer;
using QuantityMeasurementAppModelLayer.Entity;

namespace QuantityMeasurementAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService =authService;
    }
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDTO registerDTO)
    {
        _authService.Register(registerDTO);
        return Ok();
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO loginDTO)
    {
        var result=_authService.Login(loginDTO);
        return Ok(result);
    }
}