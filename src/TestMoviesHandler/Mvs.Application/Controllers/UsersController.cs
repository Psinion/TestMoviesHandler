using Microsoft.AspNetCore.Mvc;
using Mvs.Data.Services.Base;
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
        return await _usersService.Authenticate(authRequest);
    }
}