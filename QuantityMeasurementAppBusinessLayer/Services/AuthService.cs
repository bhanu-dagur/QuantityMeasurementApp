using QuantityMeasurementAppModelLayer.DTO;
using QuantityMeasurementAppRepositoryLayer;
using QuantityMeasurementAppModelLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
namespace QuantityMeasurementAppBusinessLayer.Interface;
public class AuthService : IAuthService
{
    private readonly IMeasurementHistoryRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly PasswordHasher<User> _passwordHasser;


    public AuthService(IJwtService jwtService, IMeasurementHistoryRepository _userRepository)
    {
        _jwtService = jwtService;
        this._userRepository = _userRepository;
        _passwordHasser = new PasswordHasher<User>();

    }

    public bool ValidateInfo(string email, string password, string fullName,string phone)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone) ||
            phone.Length != 10)
        {
            return false;
        }

        string emialRegex=@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        if (!Regex.IsMatch(email, emialRegex))
        {
            return false;
        }

        return true;
    }

    public bool Register(RegisterDTO user)
    {
        var fullName = user.FullName;
        var email = user.Email;
        var password = user.Password;
        var phone = user.Phone;

        if(!ValidateInfo(email, password, fullName, phone))
        {
            return false;
        }

        User userobj = new User();
        userobj.FullName = fullName;
        userobj.Email = email;
        userobj.Phone = user.Phone;

        //Hash the password
        string hashPassword= _passwordHasser.HashPassword(userobj,password);

        userobj.Password = hashPassword;  
        
        
        _userRepository.SaveUser(userobj);
        return true;
    }

    public string Login(LoginDTO user)
    {

        User loggedUser = _userRepository.GetUserByEmail(user.Email);

        if (loggedUser != null && 
            _passwordHasser.VerifyHashedPassword(loggedUser, loggedUser.Password, user.Password) == PasswordVerificationResult.Success)
        {
            return _jwtService.GenerateToken(loggedUser);
        }
    
        return null;
    }
}
