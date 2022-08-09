using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondExam.DTOs.User;
using SecondExam.Entities.Authorization;

namespace SecondExam.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public AuthenticationController(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(UserForRegistrationDto newUser)
    {
        var user = _mapper.Map<User>(newUser);
        var result = await _userManager.CreateAsync(user, newUser.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, newUser.Roles);
        }

        return Ok(result);
    }
}
