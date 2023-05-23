using Microsoft.AspNetCore.Mvc;
using Mvs.Data.Services;
using Mvs.Data.Services.Tokens;
using Mvs.Domain.DTOs;

namespace Mvs.Application.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly IUsersService _usersService;
    private readonly ITokenService _tokenService;

    public UsersController(IUsersService usersService, ITokenService tokenService)
    {
        _usersService = usersService;
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("authenticate")]
    public async Task<ActionResult<UserAuthResponseDto?>> Authenticate(UserAuthRequestDto authRequest)
    {
        var response = await _usersService.Authenticate(authRequest);

        if (response?.User == null)
        {
            return BadRequest("IncorrectUserAuth");
        }

        var tokensResult = _tokenService.GenerateTokens(new TokenInfo()
            {
                Username = response.User.Username,
            },
            authRequest.RememberMe
        ); 
        
        tokensResult.Match<ActionResult<UserAuthResponseDto?>>(
            success =>
            {
                CookieOptions option = new CookieOptions()
                {
                    // TODO: Вытащить эти цифры в единый конфиг.
                    Expires = DateTime.Now.AddMinutes(108000)
                };

                Response.Cookies.Append("refreshToken", success.refreshToken, option);

                response.AccessToken = success.accessToken;

                return response;
            },
            failure => BadRequest(failure)
        );

        return response;
    }

    [HttpPost]
    [Route("permissions")]
    public async Task<ActionResult<UserPermissionsResponseDto?>> GetPermissions()
    {
        var permissions = new UserPermissionsResponseDto()
        {
            Permissions = new List<string>()
            {
                "kek1",
                "kek2"
            }
        };

        return permissions;
    }
}