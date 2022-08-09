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
    private readonly ILogger _logger;
    public AuthenticationController(IMapper mapper, UserManager<User> userManager, IUserAuthenticationService authService, ILogger<AuthenticationController> logger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _authService = authService;
        _logger = logger;
    }

    /// <summary>
    /// Create new user
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     {
    ///        "title": "New title",
    ///        "description": "Material description",
    ///        "location": "Material location",
    ///        "educationalMaterialTypeId": t,
    ///        "authorId": 1
    ///     }
    ///
    /// </remarks>
    /// <returns>Location to new resource</returns>
    /// <response code="201">Location to newly created user</response>

    [HttpPost]
    [Route("register")]
    //[Authorize(Roles = "admin")]
    public async Task<IActionResult> RegisterUser(UserForRegistrationDto newUser)
    {
        var user = _mapper.Map<User>(newUser);
        var result = await _userManager.CreateAsync(user, newUser.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, newUser.Roles);
        }
        // TODO Change to CreatedAtAction
        return Ok(result);
    }


    /// <summary>
    /// Authenticate user
    /// </summary>
    /// <returns>JWT Token</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET
    ///     {
    ///        "userName": "matcz",
    ///          "password": "asda@!SA2Dss"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Token</response>
    /// <response code="401">Unauthorized</response>

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Authenticate(UserForAuthenticationDto user)
    {
        _logger.LogInformation("User has logged in");
        if (!await _authService.ValidateUser(user)) return Unauthorized();
        return Ok(new { Token = await _authService.CreateToken() });
    }
}
