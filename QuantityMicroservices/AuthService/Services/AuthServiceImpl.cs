using AuthService.Data;
using AuthService.Models;
using AuthService.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Services;

public class AuthServiceImpl : IAuthService
{
    private readonly AppDbContext _db;
    private readonly IJwtService _jwtService;
    private readonly PasswordHasher<User> _hasher;

    public AuthServiceImpl(AppDbContext db, IJwtService jwtService)
    {
        _db = db;
        _jwtService = jwtService;
        _hasher = new PasswordHasher<User>();
    }

    // REGISTER
    public async Task<AuthResponseDTO> Register(RegisterDTO dto)
    {
        // Check if email already registered
        bool exists = await _db.Users.AnyAsync(u => u.Email == dto.Email);
        if (exists)
            throw new Exception($"Email '{dto.Email}' already registered.");

        // Create new user
        var user = new User
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone
        };

        // Password hash 
        user.Password = _hasher.HashPassword(user, dto.Password);

        // Save User in data base
        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        // Generate Token 
        string token = _jwtService.GenerateToken(user);

        return new AuthResponseDTO
        {
            Token = token,
            Email = user.Email,
            FullName = user.FullName,
            UserId = user.Id
        };
    }

    // LOGIN

    public async Task<AuthResponseDTO> Login(LoginDTO dto)
    {
        // Search By Email
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null)
            throw new Exception("User not found with this email.");

        // Verify Password
        var result = _hasher.VerifyHashedPassword(user, user.Password, dto.Password);

        if (result != PasswordVerificationResult.Success)
            throw new Exception("Invalid password.");

        // Generate TOken
        string token = _jwtService.GenerateToken(user);

        return new AuthResponseDTO
        {
            Token = token,
            Email = user.Email,
            FullName = user.FullName,
            UserId = user.Id
        };
    }
}

