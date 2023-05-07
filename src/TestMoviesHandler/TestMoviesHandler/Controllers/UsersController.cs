using Microsoft.AspNetCore.Mvc;
using TestMoviesHandler.Data.Services.Base;
using TestMoviesHandler.Dtos;

namespace TestMoviesHandler.Controllers;

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
    public ActionResult<UserAuthResponseDto?> Authenticate(UserAuthRequestDto authRequest)
    {
        return _usersService.Authenticate(authRequest);
    }
}