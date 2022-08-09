using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondExam.DTOs.User;
using SecondExam.Entities.Authorization;
using SecondExam.AuthenticationService;
using Microsoft.AspNetCore.Authorization;

namespace SecondExam.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private IUserAuthenticationService _authService;
    public AuthenticationController(IMapper mapper, UserManager<User> userManager, IUserAuthenticationService authService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _authService = authService;
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
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


    /// <summary>
    /// Get all series with Name and Ids
    /// </summary>
    /// <returns>All series in DB</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET
    ///     {
    ///        "SerieId": "",
    ///        "SerieName": "",
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Returns all series</response>
    /// <response code="401">If the item is null</response>
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Authenticate(UserForAuthenticationDto user)
    {
        if (!await _authService.ValidateUser(user)) return Unauthorized();
        return Ok(new { Token = await _authService.CreateToken() });
    }
}
