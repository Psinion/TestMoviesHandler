using Microsoft.AspNetCore.Mvc;
using Mvs.Data.Services;
using Mvs.Domain.DTOs;

namespace Mvs.Application.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost]
    [Route("authenticate")]
    public async Task<ActionResult<UserAuthResponseDto?>> Authenticate(UserAuthRequestDto authRequest)
    {
        var response = await _usersService.Authenticate(authRequest);

        if (response == null)
        {
            return BadRequest("error");
        }

        return response;
    }
}