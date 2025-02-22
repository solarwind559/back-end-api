using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api1.Models;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthController> _logger;


    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, ILogger<AuthController> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _logger = logger; // Initialize the logger


    }

    [HttpPost("token")]
    public async Task<IActionResult> CreateToken([FromBody] Login login)
    {
        var user = await _userManager.FindByNameAsync(login.Username);

        if (user == null)
        {
            // Log user not found
            return Unauthorized(new { message = "user not found" });
        }

        if (!await _userManager.CheckPasswordAsync(user, login.Password))
        {
            // Log password check failed
            return Unauthorized(new { message = "password not valid" });
        }

        if (string.IsNullOrEmpty(user.UserName))
        {
            // Log that UserName is null or empty
            return Unauthorized(new { message = "Invalid user data" });
        }

        var jwtKey = _configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(jwtKey))
        {
            // Log that JWT Key is missing
            throw new InvalidOperationException("JWT Key is not configured.");
        }

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Role, "User") // Adjust role as necessary
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds);

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }


    [HttpPost("logout")]
    [Authorize]
    public IActionResult Logout()


    {
        Console.WriteLine("Logout method called.");

        // Check if the user is authenticated
        if (User.Identity.IsAuthenticated)
        {
            Console.WriteLine($"User is authenticated. Username: {User.Identity.Name}");
        }
        else
        {
            Console.WriteLine("User is not authenticated.");
        }
        // Log the entry into the method
        _logger.LogInformation("Logout method called.");

        // Check if the user is authenticated
        if (User.Identity.IsAuthenticated)
        {
            _logger.LogInformation("User is authenticated. Username: {Username}", User.Identity.Name);
        }
        else
        {
            _logger.LogWarning("User is not authenticated.");
        }

        // Here, you can handle token invalidation or session management
        return Ok(new { message = "Logged out successfully" });
    }

}