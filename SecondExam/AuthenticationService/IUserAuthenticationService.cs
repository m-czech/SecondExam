using Microsoft.AspNetCore.Identity;
using SecondExam.DTOs.User;

namespace SecondExam.AuthenticationService;

public interface IUserAuthenticationService
{
    public Task<bool> ValidateUser(UserForAuthenticationDto user);
    public Task<string> CreateToken();
}
