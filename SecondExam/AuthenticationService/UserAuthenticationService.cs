using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SecondExam.DTOs.User;
using SecondExam.Entities.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecondExam.AuthenticationService;

public class UserAuthenticationService : IUserAuthenticationService
{
    private readonly UserManager<User> _manager;
    private readonly IConfiguration _configuration;
    private User? _user;

    public UserAuthenticationService(UserManager<User> manager, IConfiguration configuration)
    {
        _manager = manager;
        _configuration = configuration;
    }

    public async Task<string> CreateToken()
    {
        var credentials = GetSigningCredentials();
        var claims = await GetClaims();
        var jwtOptions = GenerateTokenOptions(credentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(jwtOptions);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials credentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JWT");
        var tokenOptions = new JwtSecurityToken
        (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials
        );

        return tokenOptions;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_configuration["SecretKey"]);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };

        var roles = await _manager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto user)
    {
        _user = await _manager.FindByNameAsync(user.UserName);
        var result = _user == null ? false : await _manager.CheckPasswordAsync(_user, user.Password); ;
        if (!result)
        {
            //TODO Logger
        }
        return result;
    }
}
