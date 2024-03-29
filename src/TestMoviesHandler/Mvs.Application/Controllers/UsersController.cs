﻿using Microsoft.AspNetCore.Mvc;
using Mvs.Application.Middlewares;
using Mvs.Data.Services;
using Mvs.Data.Services.Tokens;
using Mvs.Domain.DTOs;

namespace Mvs.Application.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ICredentialsService _credentialsService;
    private readonly IUsersService _usersService;
    private readonly ITokenService _tokenService;

    public UsersController(
          ICredentialsService credentialService
        , IUsersService usersService
        , ITokenService tokenService
        )
    {
        _credentialsService = credentialService;
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
                Id = response.User.Id,
                Username = response.User.Username,
            },
            authRequest.RememberMe
        ); 
        
        return tokensResult.Match<ActionResult<UserAuthResponseDto?>>(
            success =>
            {
                CookieOptions option = new CookieOptions()
                {
                    // TODO: Вытащить эти цифры в единый конфиг.
                    Expires = DateTime.Now.AddMinutes(108000)
                };

                Response.Cookies.Append("refreshToken", success.refreshToken, option);

                response.Token = success.accessToken;

                return response;
            },
            failure => BadRequest(failure)
        );
    }

    [CustomAuthorize]
    [HttpGet]
    [Route("refresh")]
    public async Task<ActionResult<UserAuthResponseDto?>> Refresh()
    {
        var currentUser = _credentialsService.CurrentUser;
        var tokensResult = _tokenService.GenerateTokens(new TokenInfo()
            {
                Id = currentUser.Id,
                Username = currentUser.Username,
            }
        );

        return tokensResult.Match<ActionResult<UserAuthResponseDto?>>(
            success =>
            {
                CookieOptions option = new CookieOptions()
                {
                    // TODO: Вытащить эти цифры в единый конфиг.
                    Expires = DateTime.Now.AddMinutes(108000)
                };

                Response.Cookies.Append("refreshToken", success.refreshToken, option);

                var response = new UserAuthResponseDto()
                {
                    User = new UserDto()
                    {
                        Username = currentUser.Username
                    },
                    Token = success.accessToken
                };

                return response;
            },
            failure => BadRequest(failure)
        );
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